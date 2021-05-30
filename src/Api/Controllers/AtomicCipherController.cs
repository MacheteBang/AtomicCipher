using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AtomicCipher.Api
{
   [ApiController]
   [Route("{controller}")]
   public class AtomicCipherController : ControllerBase
   {
      [HttpGet]
      [Route("encrypt")]
      [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Message))]
      public ActionResult EncryptMessage([FromQuery][BindRequired] string unencryptedMessage)
      {
         Models.Message message = new() {
            MessageText = Cipher.EncryptMessage(unencryptedMessage)
         };

         return Ok(message);
      }
      [HttpPost]
      [Route("encrypt")]
      [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Message))]
      public ActionResult EncryptMessage([FromBody][BindRequired] Models.Message unencryptedMessage)
      {
         Models.Message message = new() {
            MessageText = Cipher.EncryptMessage(unencryptedMessage.MessageText)
         };

         return Ok(message);
      }

      
      [HttpGet]
      [Route("decrypt")]
      [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Message))]
      public ActionResult DecryptMessage([FromQuery][BindRequired] string encryptedMessage)
      {
         Models.Message message = new() {
            MessageText = Cipher.DecryptMessage(encryptedMessage)
         };

         return Ok(message);
      }
      [HttpPost]
      [Route("decrypt")]
      [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Message))]
      public ActionResult DecryptMessage([FromBody][BindRequired] Models.Message encryptedMessage)
      {
         Models.Message message = new() {
            MessageText = Cipher.DecryptMessage(encryptedMessage.MessageText)
         };

         return Ok(message);
      }
   }
}