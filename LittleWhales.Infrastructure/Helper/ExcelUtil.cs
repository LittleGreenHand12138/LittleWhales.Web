using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using LittleWhales.Infrastructure;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace LittleWhales.Extensions.Infrastructure
{
    //NPOI方式
    //NPOI 是 POI 项目的 .NET 版本。POI是一个开源的Java读写Excel、WORD等微软OLE2组件文档的项目。使用 NPOI 你就可以在没有安装 Office 或者相应环境的机器上对 WORD/EXCEL 文档进行读写。
    //优点：读取Excel速度较快，读取方式操作灵活性
    //缺点：需要下载相应的插件并添加到系统引用当中。
    public class ExcelUtil
    {
        /// <summary>
        /// 将excel文件内容读取到DataTable数据表中
        /// </summary>
        /// <param name="fileName">文件完整路径名</param>
        /// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名：true=是，false=否</param>
        /// <returns>DataTable数据表</returns>
        public static DataTable ReadExcelToDataTable(string fileName, string sheetName = null, bool isFirstRowColumn = true)
        {
            //定义要返回的datatable对象
            DataTable data = new DataTable();
            //excel工作表
            ISheet sheet = null;
            //数据开始行(排除标题行)
            int startRow = 0;
            try
            {
                if (!File.Exists(fileName))
                {
                    return null;
                }
                //根据指定路径读取文件
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //根据文件流创建excel数据结构
                IWorkbook workbook = WorkbookFactory.Create(fs);
                //IWorkbook workbook = new HSSFWorkbook(fs);
                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //如果第一行是标题列名
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将文件流读取到DataTable数据表中
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名：true=是，false=否</param>
        /// <returns>DataTable数据表</returns>
        public static DataTable ReadStreamToDataTable(Stream fileStream, string sheetName = null, bool isFirstRowColumn = true)
        {
            //定义要返回的datatable对象
            DataTable data = new DataTable();
            //excel工作表
            ISheet sheet = null;
            //数据开始行(排除标题行)
            int startRow = 0;
            try
            {
                //根据文件流创建excel数据结构,NPOI的工厂类WorkbookFactory会自动识别excel版本，创建出不同的excel数据结构
                IWorkbook workbook = WorkbookFactory.Create(fileStream);
                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //如果第一行是标题列名
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null || row.FirstCellNum < 0) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            //同理，没有数据的单元格都默认是null
                            ICell cell = row.GetCell(j);
                            if (cell != null)
                            {
                                if (cell.CellType == CellType.Numeric)
                                {
                                    //判断是否日期类型
                                    if (DateUtil.IsCellDateFormatted(cell))
                                    {
                                        dataRow[j] = row.GetCell(j).DateCellValue;
                                    }
                                    else
                                    {
                                        dataRow[j] = row.GetCell(j).ToString().Trim();
                                    }
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString().Trim();
                                }
                            }
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetColumnPos(string rule, DataTable dt)
        {
            int rtn = -1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (RegexUtil.New(rule).IsMatch(dt.Columns[i].ColumnName))
                {
                    rtn = i;
                    break;
                }
            }
            return rtn;
        }

        /// <summary>
        /// 生成车辆导入模板
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="strain"></param>
        /// <param name="VehicleUse"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string CreateVehicleExcel(string[] brand, string[] carcategory, string[] useProperties, string[] strain, string[] vehicleUse, string Path)
        {

            //创建工作簿
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
           // string[] headName = { "机动车所有人", "品牌", "品牌车型", "车牌", "发动机号", "VIN码", "购车日期","车龄", "车辆用途", "是否账期" };
            string[] headName = { "车牌号", "车辆类型", "所有人", "使用性质", "品牌", "品系", "型号", "发动机号", "VIN码", "车龄", "车辆用途", "挂靠公司", "注册日期", "发证日期", "是否账期" };
            try
            {
                //创建Sheet页
                ISheet sheet = hssfworkbook.CreateSheet("Sheet1");
                #region   表头
                IRow Irows2 = sheet.CreateRow(0);
                for (int j = 0; j < headName.Length; j++)
                {
                    ICell Icell2 = Irows2.CreateCell(j);
                    ICellStyle Istyle2 = hssfworkbook.CreateCellStyle();
                    //将新的样式赋给单元格
                    Icell2.CellStyle = Istyle2;
                    Icell2.SetCellValue(headName[j]);
                }
                //车辆类型
                CellRangeAddressList regions1 = new CellRangeAddressList(1, 65535, 1, 1);
                DVConstraint constraint1 = DVConstraint.CreateExplicitListConstraint(carcategory);
                HSSFDataValidation dataValidate1 = new HSSFDataValidation(regions1, constraint1);
                sheet.AddValidationData(dataValidate1);
                //使用性质
                CellRangeAddressList regions3 = new CellRangeAddressList(1, 65535, 3, 3);
                DVConstraint constraint3 = DVConstraint.CreateExplicitListConstraint(useProperties);
                HSSFDataValidation dataValidate3 = new HSSFDataValidation(regions3, constraint3);
                sheet.AddValidationData(dataValidate3);
                //品牌
                CellRangeAddressList regions4 = new CellRangeAddressList(1, 65535, 4, 4);
                DVConstraint constraint4 = DVConstraint.CreateExplicitListConstraint(brand);
                HSSFDataValidation dataValidate4 = new HSSFDataValidation(regions4, constraint4);
                sheet.AddValidationData(dataValidate4);
                //品系
                CellRangeAddressList regions5 = new CellRangeAddressList(1, 65535, 5, 5);
                DVConstraint constraint5 = DVConstraint.CreateExplicitListConstraint(strain);
                HSSFDataValidation dataValidate5 = new HSSFDataValidation(regions5, constraint5);
                sheet.AddValidationData(dataValidate5);
                //车辆用途
                CellRangeAddressList regions10 = new CellRangeAddressList(1, 65535, 10, 10);
                DVConstraint constraint10 = DVConstraint.CreateExplicitListConstraint(vehicleUse);
                HSSFDataValidation dataValidate10 = new HSSFDataValidation(regions10, constraint10);
                sheet.AddValidationData(dataValidate10);
                //是否账期
                CellRangeAddressList regions14 = new CellRangeAddressList(1, 65535, 14, 14);
                DVConstraint constraint14 = DVConstraint.CreateExplicitListConstraint(new string[] { "是", "否" });
                HSSFDataValidation dataValidate14 = new HSSFDataValidation(regions14, constraint14);
                sheet.AddValidationData(dataValidate14);
                #endregion


                //for (int h = 0; h < 9; h++)
                //{
                //    sheet.AutoSizeColumn(h);  //会按照值的长短 自动调节列的大小
                //}
            }
            catch (Exception ex) { } 
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            string fileName = GlobalSwitch.VehiclePathName;
            using (FileStream file = new FileStream(Path + "\\" + fileName, FileMode.Create))
            {
                hssfworkbook.Write(file);　　//创建test.xls文件。
                file.Close();
                 
            }
            return Path + "\\" + fileName;
        }

        /// <summary>
        /// 生成司机导入模板
        /// </summary>
        /// <param name="driversLicenseCategor"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string CreateDriverExcel( string[] driversLicenseCategor,string Path)
        {
            //创建工作簿
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            string[] headName = { "姓名", "电话", "性别", "年龄", "驾龄", "驾驶证类型", "驾驶车辆" };
            try
            {
                //创建Sheet页
                ISheet sheet = hssfworkbook.CreateSheet("Sheet1");
                #region   表头
                IRow Irows2 = sheet.CreateRow(0);
                for (int j = 0; j < headName.Length; j++)
                {
                    ICell Icell2 = Irows2.CreateCell(j);
                    ICellStyle Istyle2 = hssfworkbook.CreateCellStyle();
                    //将新的样式赋给单元格
                    Icell2.CellStyle = Istyle2;
                    Icell2.SetCellValue(headName[j]);
                }
               
                CellRangeAddressList regions2 = new CellRangeAddressList(1, 65535, 2, 2);
                DVConstraint constraint2 = DVConstraint.CreateExplicitListConstraint(new string[] { "男", "女" });
                HSSFDataValidation dataValidate2 = new HSSFDataValidation(regions2, constraint2);
                sheet.AddValidationData(dataValidate2);
                CellRangeAddressList regions5 = new CellRangeAddressList(1, 65535, 5, 5);
                DVConstraint constraint5 = DVConstraint.CreateExplicitListConstraint(driversLicenseCategor);
                HSSFDataValidation dataValidate5 = new HSSFDataValidation(regions5, constraint5);
                sheet.AddValidationData(dataValidate5);
                 
                #endregion


                //for (int h = 0; h < 9; h++)
                //{
                //    sheet.AutoSizeColumn(h);  //会按照值的长短 自动调节列的大小
                //}
            }
            catch (Exception ex) { }
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            string fileName = GlobalSwitch.DriverPathName;
            using (FileStream file = new FileStream(Path + "\\" + fileName, FileMode.Create))
            {
                hssfworkbook.Write(file);
                file.Close(); 
            } 
            return Path + "\\" + fileName; 
        }
    }
}