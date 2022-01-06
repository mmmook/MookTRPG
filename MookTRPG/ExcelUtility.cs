using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public static class ExcelUtility
    {
        public static IWorkbook workbook = null;

        public static void InitCharacterCard(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // 2007版本  
                if (filePath.IndexOf(".xlsx") > 0)
                {
                    fs.Position = 0;
                    workbook = new XSSFWorkbook(fs);
                }
                // 2003版本  
                else if (filePath.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    
                }
                else
                {
                    Console.WriteLine("未读取到！");
                }
            }
        }

        public static object GetValue(int rowNum, int cellNum, int sheetNum = 0)
        {
            ISheet sheet = workbook.GetSheetAt(sheetNum);
            if (sheet != null)
            {
                sheet.ForceFormulaRecalculation = true;
                ICell cell = sheet.GetRow(rowNum).GetCell(cellNum);
                if (cell != null)
                {
                    switch (cell.CellType)
                    {
                        case CellType.Blank:
                            return "";
                        case CellType.Boolean:
                            return cell.BooleanCellValue;
                        case CellType.Numeric:
                            return cell.NumericCellValue;
                        case CellType.String:
                            return cell.StringCellValue;
                        case CellType.Error:
                            return cell.ErrorCellValue;
                        case CellType.Formula:
                            XSSFFormulaEvaluator xEvaluator = new XSSFFormulaEvaluator(workbook);
                            return xEvaluator.EvaluateInCell(cell).NumericCellValue;
                        default:
                            return "=" + cell.CellFormula;
                    }
                }
            }
            return null;
        }

        public static void SetValue(string value, int rowNum, int cellNum, int sheetNum = 0)
        {
            ISheet sheet = workbook.GetSheetAt(sheetNum);
            if (sheet != null)
            {
                sheet.ForceFormulaRecalculation = true;
                ICell cell = sheet.GetRow(rowNum).GetCell(cellNum);
                if (cell != null)
                {
                    cell.SetCellValue(value);
                }
            }
        }

        public static void SetValue(int value, int rowNum, int cellNum, int sheetNum = 0)
        {
            ISheet sheet = workbook.GetSheetAt(sheetNum);
            if (sheet != null)
            {
                sheet.ForceFormulaRecalculation = true;
                ICell cell = sheet.GetRow(rowNum).GetCell(cellNum);
                if (cell != null)
                {
                    cell.SetCellValue(value);
                }
            }
        }

        public static void SetValueNum(int value, int rowNum, int cellNum, int sheetNum = 0)
        {
            if (value == 0)
                return;
            ISheet sheet = workbook.GetSheetAt(sheetNum);
            if (sheet != null)
            {
                sheet.ForceFormulaRecalculation = true;
                ICell cell = sheet.GetRow(rowNum).GetCell(cellNum);
                if (cell != null)
                {
                    cell.SetCellValue(value);
                }
            }
        }

        public static void SetValue(bool value, int rowNum, int cellNum, int sheetNum = 0)
        {
            ISheet sheet = workbook.GetSheetAt(sheetNum);
            if (sheet != null)
            {
                sheet.ForceFormulaRecalculation = true;
                ICell cell = sheet.GetRow(rowNum).GetCell(cellNum);
                if (cell != null)
                {
                    cell.SetCellValue(value);
                }
            }
        }




        public static void SaveCharacterCard(string filePath = "")
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }
    }
}
