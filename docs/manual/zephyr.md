# [Stylelabs QA Manual](../index)

## Zephyr test case formatter

### Description

The Zephyr test case formatter is a command that exports test cases from a CSV file to formated Excel file(s) using a given Excel template.

### Parameters
* inputCsvFilePath: Full path to the input CSV file with the test cases. Required.
* outputExcelFilePath: Full path of the output Excel file. Optional.
* templateExcelFilePath: Full path to the Excel template file. Required.
* exportOption: Export option. Available values: none, sheet, file. Default is none. Optional.
* spacing: Number of row spacing, when the export option is sheet. Default is 3. Optional.

### Usage
	Stylelabs.M.Tools.ZephyrTestCaseFormatter.exe --inputCsvFilePath="C:\inputCsvFile.csv" --outputExcelFilePath="C:\outputExcelFile.xlsx" --templateExcelFilePath="C:\ExportTemplate.xlsx" --exportOption="none" --spacing="4"
	
####Help
    Stylelabs.M.Tools.ZephyrTestCaseFormatter.exe --help

