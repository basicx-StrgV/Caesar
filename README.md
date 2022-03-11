# Caesar
 
## What is this project

This project was a small school assignment as part of my vocational training.  
Therefore this is not a finished product and the application is not optimized. This repository is intended as a reference and archive.

## What does it do

The goal of this assignment was to create a small program that encrypts and decrypts text with the [Caesar cipher](https://en.wikipedia.org/wiki/Caesar_cipher).

To accomplish this I created a “CaesarCharset” that implements the charset as a looping list, that can loop in both directions.  
The charset also implements the shift value and a value that indicates how often the encryption/decryption should run on a string.  
With this the shift value can be over 9000 on a char set that has just 100 entries and the encryption/decryption can be run multiple times on a string before it is returned.  

This is also done to make the encryption a little “safer”, because to decrypt it the charset, shift value and the number of encryption runs needs to be known.  
But this does not change the fact that the caesar cipher is highly insecure and should not be used to encrypt sensitive data.

![sample image](https://raw.githubusercontent.com/basicx-StrgV/Caesar/main/images/caesarSample.png)
