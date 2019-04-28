using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Movies.Models;

namespace Movies.Repository
{
    internal class FileManager
    {
        public FileManager() {}


        public async Task<InitialMoviesDataDTO> InitialImportFromFile(FileRequestDTO requestDTO)
        {
            var listName = "flm";
            var columnsNumber = new int[] { 2 };
            var topRowNumber = 2;

            //var result2 = new List<List<string>>();
            var films = new List<Film>();
            string cellValue;
            List<string> rowValue;

            await Task.Run(() =>
            {
                using (var wb = new XLWorkbook(requestDTO.FileExcel.InputStream, XLEventTracking.Disabled))
                {
                    var ws = wb.Worksheet(listName);
                    {
                        var row = ws.Row(topRowNumber);
                        while (!row.Cell(columnsNumber[0]).IsEmpty())
                        {
                            //rowValue = new List<string>();
                            var film = new Film();
                            foreach (var col in columnsNumber)
                            {
                                cellValue = row.Cell(col).GetString();
                                film.Name = cellValue;
                                //rowValue.Add(cellValue);
                            }
                            films.Add(film);
                            //result2.Add(rowValue);
                            row = row.RowBelow();
                        }
                    }
                }
            });

            await Task.Delay(10);
            return new InitialMoviesDataDTO { Films=films,   SearchCount = films.Count() };
        }

    }
}