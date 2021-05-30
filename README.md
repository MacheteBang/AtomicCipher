# Atomic Cipher
To practice, I created a cipher based on the periodic table of elements.  This simple cipher takes in a message, and searches for any element's symbol that contains that character, and returns the atomic number prefixed but the position (indicated by the count of exclamation points).
Inversely, it can take the encrypted message and decrypt it.

The fun thing behind it is that encrypting the message will product different results for the same message.

## For Example...
Encrypting the following message
    
    Do or do not, there is no try

results in:

    !110!76 !!27!!38 !66!!67 !11!!27!81, !90!80!!54!104!!10 !!14!16 !11!!42 !69!111!70
or

    !110!!84 !!42!111 !!64!!67 !93!!42!117, !!109!67!!58!104!!52 !!83!!76 !113!!102 !90!!68!39
or

    !66!!67 !!42!75 !!46!118 !!112!!102!52, !22!!113!!54!111!99 !!83!!108 !28!8 !22!44!70
and these items, re-decrypted:

    DO or Do NoT, THeRe iS No TRY
    Do oR do NoT, tHeRe is No TrY
    Do oR dO noT, TheRE is NO TRY

The motivation behind this is to simply practice with a challenge in hand.

## Installation
The application is completely self contained and has three projects:
* AtomicCipher.csproj - This is the core class library that is doing the work and is consumed by the other to projectS:
* AtomicCipher.Api.csproj - This is a quick WebApi written to test out the code.
* AtomicCipher.Console.csproj - This is a quick console app written to test out the code.

## Usage
To use this, the only project needed is *AtomicCipher.csproj*.
