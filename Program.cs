
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Newtonsoft.Json; 

class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the file path:");
            string path = Console.ReadLine();
            string h = ReadExcel(path);
            Console.WriteLine(h);
//            writetxt();
            Console.WriteLine("Done.");
            Console.Write("Press any key to continue...");

            Console.ReadKey();
        }
        
         
        static string ReadExcel(string path)
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            //using (var stream = new FileStream(@"D:\test.xlsx", FileMode.Open))
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                Console.WriteLine(cellCount.ToString());   
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                        Console.WriteLine(cell.ToString());
                    } 
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    string table = "";
                    string condiction = "";
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            {
                                rowList.Add(row.GetCell(j).ToString());
   /*                             
                                if(j==1){
                                    table = row.GetCell(j).ToString();
                                    Console.WriteLine("table= "+ table);
                                }
                                if(j==2){
                                    condiction = row.GetCell(j).ToString();
                                    Console.WriteLine("condiction= "+ condiction);
                                }
                                writetxt(table, "where", condiction);
*/
//                               Console.WriteLine(row.GetCell(j).ToString());
                            }
                        }
                    }
                    if(rowList.Count>0)
                    dtTable.Rows.Add(rowList.ToArray());
                    writetxt(rowList);
                    rowList.Clear(); 
                }
            }
            return JsonConvert.SerializeObject(dtTable);
        }

        static void writetxt(string table , string filter, string condiction){
            // Write file using StreamWriter
            //StreamWriter sw = new StreamWriter(@"C:\text.txt", true);
            //第二個參數設定為true表示不覆蓋原本的內容，把新內容直接添加進去

            string fullPath = @"D:\result.txt";
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
            writer.WriteLine(table);
            writer.WriteLine(filter + " " + condiction);
            
            /*
            writer.WriteLine("Monica Rathbun");
            writer.WriteLine("Vidya Agarwal");
            writer.WriteLine("Mahesh Chand");
            writer.WriteLine("Vijay Anand");
            writer.WriteLine("Jignesh Trivedi");
            */
            }
                          

            // Read a file
            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);

        }

        static void writetxt(List<string> rowList){
            // Write file using StreamWriter
            //StreamWriter sw = new StreamWriter(@"C:\text.txt", true);
            //第二個參數設定為true表示不覆蓋原本的內容，把新內容直接添加進去

            string fullPath = @"D:\result.txt";

            List<string> myStringLists = new List<string>();
            myStringLists = rowList;

            foreach(string str in myStringLists)
            {
                Console.WriteLine("str=" + str);

            }
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
            writer.WriteLine("myStringLists[0]=" + myStringLists[0]);
            writer.WriteLine("myStringLists[1]=" + myStringLists[1]);
            
            /*
            writer.WriteLine("Monica Rathbun");
            writer.WriteLine("Vidya Agarwal");
            writer.WriteLine("Mahesh Chand");
            writer.WriteLine("Vijay Anand");
            writer.WriteLine("Jignesh Trivedi");
            */
            }
                          

            // Read a file
            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);

        }

/*
        static void WriteExcel()
        {
            List<UserDetails> persons = new List<UserDetails>()
            {
                new UserDetails() {ID="1001", Name="ABCD", City ="City1", Country="USA"},
                new UserDetails() {ID="1002", Name="PQRS", City ="City2", Country="INDIA"},
                new UserDetails() {ID="1003", Name="XYZZ", City ="City3", Country="CHINA"},
                new UserDetails() {ID="1004", Name="LMNO", City ="City4", Country="UK"},
           };
 
            // Lets converts our object data to Datatable for a simplified logic.
            // Datatable is most easy way to deal with complex datatypes for easy reading and formatting.
 
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(persons), (typeof(DataTable)));
            var memoryStream = new MemoryStream();
             
            using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Sheet1");
 
                List<String> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;
               
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }
 
                int rowIndex = 1;
                foreach (DataRow dsrow in table.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (String col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }
 
                    rowIndex++;
                }
                workbook.Write(fs,true);
            }
 
        }
        */
        
    }