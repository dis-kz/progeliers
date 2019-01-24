using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SynectixReport
    {
        private static SynectixReport _instance;

        //свойство "экземпляр"
        public static SynectixReport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SynectixReport();
                return _instance;
            }
        }

        public string GetAdapterCommandText(bool inProject, int idProjectNumber, int analog)
        {
            string text = @"SELECT
  EquipNote.Text AS colConNum
 ,Manufacturer.Name AS colManufacturer
 ,Seria.Name AS colSeria
 ,CbCurrent.Value AS colCbCurrent
 ,IcuLiteral.Literal AS colIcuLiteral
 ,PoleNumber.Number AS colPoleNumber
 ,DisModel.Name AS colDisModel
 ,DisCurrent.Value AS colDisCurrent
 ,CurrentBreaker.CbCatNumber AS colCbCatNumber
 ,CurrentBreaker.DisCatNumber AS colDisCatNumber
 ,CurrentBreaker.Note AS colNote
FROM dbo.CurrentBreaker
INNER JOIN dbo.Manufacturer
  ON CurrentBreaker.IdManufacturer = Manufacturer.Id
INNER JOIN dbo.Seria
  ON CurrentBreaker.IdSeria = Seria.Id
INNER JOIN dbo.CbCurrent
  ON CurrentBreaker.IdCbCurrent = CbCurrent.Id
INNER JOIN dbo.IcuLiteral
  ON CurrentBreaker.IdIcuLiteral = IcuLiteral.Id
INNER JOIN dbo.PoleNumber
  ON CurrentBreaker.IdPoleNumber = PoleNumber.Id
INNER JOIN dbo.DisModel
  ON CurrentBreaker.IdDisModel = DisModel.Id
INNER JOIN dbo.DisCurrent
  ON CurrentBreaker.IdDisCurrent = DisCurrent.Id
INNER JOIN dbo.ProjectEquipment
  ON ProjectEquipment.IdCbr = CurrentBreaker.Id";

            if (inProject)
            {
                text += String.Format(@"
INNER JOIN dbo.ProjectNumber
  ON ProjectEquipment.IdProjectNumber = ProjectNumber.Id
INNER JOIN dbo.EquipNote
  ON ProjectEquipment.IdNote = EquipNote.Id
WHERE ProjectNumber.Id = {0}
AND ProjectEquipment.Analog = {1}", idProjectNumber, analog);
            }
            else
            {
                text += String.Format(@"
INNER JOIN dbo.EquipNote
  ON ProjectEquipment.IdNote = EquipNote.Id
  WHERE ISNULL(ProjectEquipment.IdProjectNumber, 0) = 0 AND ProjectEquipment.Analog = {0}", analog);
            }

            return text;
        }
    }
}
