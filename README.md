# Atomic Cipher
To practice, I created a cipher based on the periodic table of elements.  This simple cipher takes in a message, and searches for any element's symbol that contains that character, and returns the atomic number prefixed but the position (indicated by the count of exclamation points).
Inversely, it can take the encrypted message and decrypt it.

The motivation behind this is to simply practice with a challenge in hand.

## Installation
The application is completely self contained and has three projects:
* AtomicCipher.csproj - This is the core class library that is doing the work and is consumed by the other to projectS:
* AtomicCipher.Api.csproj - This is a quick WebApi written to test out the code.
* AtomicCipher.Console.csproj - This is a quick console app written to test out the code.

## Usage
To use this, the only project needed is *AtomicCipher.csproj*.
