# OCR Text Comparer
Allows user to select two image files. Then after pressing 'Compare' button texts from two images are compared and differences highlighted.

<img src="./docs/images/1.png">

## How it works
Imges are preprocessed and texts are extracted from both images using Tesseract ocr engine. These texts are then compared using google's diff-match-path algo. Result is put into text box below images. When user clicks on line in text box, this line is highlighted (+ pan & zoom) in both original images allowing quick peek into text's original location.

Quality of results is highly dependent on quality of ocr. 
For best results use:
 - images with at least 400 DPI (600 DPI and more is optimal)
 - perform comparison selecting appropriate language
  - to keep size of project in check only 'English' language is included, to provide more see src/OcrTextComparer/OcrTextComparer/tessdata/

## Code organization
Solution contains two projects - *ImageCompare* and *OcrTextComparer*. *ImageCompare* project contains everything related to comparison, including compare control - *ImageCompareControl*. *OcrTextComparer* project basically acts as a host for compare control, it contains components required to provide inputs for compare control.

## Dependencies
 - .NET Framework 4
 - Nuget packages:
   - EmguCV
   - Magick.NET-Q8-AnyCPU
   - OpenTK
   - OpenTK.GLControl
   - Tesseract
   - ZedGraph

