# NSFW_Scanner
Powered by [百度图像审核API(Baidu Image Censoring)](https://ai.baidu.com/tech/imagecensoring)
- Credits to the great idea and work of [Cover](http://coverapp.me/) (Cover Gallery Protector) team.

## Token.config
  Create/Put under the startup directory of the program.
  ```XML
  <?xml version="1.0" encoding="utf-8" ?>
  <root>
    <APIKey>...YourAPIKeyHere...</APIKey>
    <SecretKey>...SecretKeyHere...</SecretKey>
    <MaxSize>1000000</MaxSize>
  </root>
  ```
  `MaxSize` is refered as max length (byte) of base64 coded file, and should not exceed 4M acrroding to Baidu's official document.

## Judgement
![Judgement](Screenshot/1.PNG)

## NSFW_Scanner

![NSFW_Scanner](Screenshot/4.PNG)
