# 阿里OCR活动包

[阿里云](https://ai.aliyun.com/ocr)提供多种OCR，如增值税发票、营业执照、驾驶证等，可以用于多种RPA流程。本代码库基于[云可扩展OCR活动包](https://github.com/allenlooplee/CloudOcrActivitiesPack)开发，打通UiPath和阿里OCR，让开发者能在UiPath Studio中通过简单的拖放和设置把阿里OCR用到相关流程中，从而加速开发过程。

## 快速开始

在UiPath Studio中使用阿里OCR活动包可以遵循以下步骤：
1. **创建项目**：使用[templates/CloudOcrBasicProcess](https://github.com/allenlooplee/CloudOcrActivitiesPack/tree/master/templates/CloudOcrBasicProcess)模版创建OCR流程，你可以查阅[它的文档](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/docs/cloud-ocr-basic-process.md)。
2. **安装活动包**：在GitHub Releases中下载[v0.1.0 pre-release](https://github.com/allenlooplee/AliOcrActivitiesPack/releases/tag/v0.1.0)，并在UiPath Studio的Manage Packages中安装。
3. **配置密钥**：在[config/ali_ocr_config.xlsx](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/templates/CloudOcrBasicProcess/config/ali_ocr_config.xlsx)中填入相应的appcode。
4. **加载密钥**: 使用[snippets/LoadAliOcrConfig.xaml](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/snippets/LoadAliOcrConfig.xaml)代码片段从上述配置文件加载密钥。
5. **使用活动**：把你想使用的OCR活动从Activities面板拖到OCR Scope活动中。

## OCR活动清单

本活动包支持以下[云可扩展OCR活动包](https://github.com/allenlooplee/CloudOcrActivitiesPack)的OCR活动：

#|名称|类型|活动
---|---|---|---
1|[银行卡识别](https://help.aliyun.com/document_detail/51930.html)|证照类|[BankCardActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/BankCardActivity.cs)
2|[营业执照识别](https://help.aliyun.com/document_detail/43167.html)|公司商铺类|[BusinessLicenseActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/BusinessLicenseActivity.cs)
3|[身份证识别](https://help.aliyun.com/document_detail/30407.html)|证照类|[IdCardActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/IdCardActivity.cs)
4|[出租车票识别](https://help.aliyun.com/document_detail/91909.html)|票据类|[TaxiReceiptActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/TaxiReceiptActivity.cs)
5|[火车票识别](https://help.aliyun.com/document_detail/66335.html)|票据类|[TrainTicketActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/TrainTicketActivity.cs)
6|[户口本识别](https://help.aliyun.com/document_detail/92723.html)|证照类|[HouseholdRegisterActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/HouseholdRegisterActivity.cs)
7|[护照识别](https://help.aliyun.com/document_detail/51985.html)|证照类|[PassportActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/PassportActivity.cs)
8|[驾驶证识别](https://help.aliyun.com/document_detail/30408.html)|车辆相关|[DriverLicenseActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/DriverLicenseActivity.cs)
9|[行驶证识别](https://help.aliyun.com/document_detail/42774.html)|车辆相关|[VehicleLicenseActivity](https://github.com/allenlooplee/CloudOcrActivitiesPack/blob/master/Cloud.Ocr/Cloud.Ocr.Activities/Activities/VehicleLicenseActivity.cs)

## 其他代码库和参考资料
* [云可扩展OCR活动包](https://github.com/allenlooplee/CloudOcrActivitiesPack)
* [阿里OCR API文档](https://help.aliyun.com/document_detail/30403.html)
* [阿里OCR官方示例代码](https://github.com/ALIBABAOCR/OCR_EXAMPLE)
* [JSON.NET](https://github.com/JamesNK/Newtonsoft.Json)
* [How to Create Activities](https://docs.uipath.com/integrations/docs/how-to-create-activities)
* [Testing Framework for UiPath](https://connect.uipath.com/marketplace/components/uipath-testing-framework)
* [Windows Workflow Foundation](https://docs.microsoft.com/en-us/dotnet/framework/windows-workflow-foundation/)

## 许可协议

本代码库遵循[MIT许可协议](https://github.com/allenlooplee/AliOcrActivitiesPack/blob/master/LICENSE)，可作商业用途。

## 特别声明
* 本活动包并非官方出品，不存在官方支持。
* 本活动包并不包含任何本地模型，你的票据将会发往阿里云进行文字识别。
* 本活动包并不收取任何费用，阿里云可能[根据你的使用情况收取费用](https://www.aliyun.com/ntms/market/aliyunocr201811)。
