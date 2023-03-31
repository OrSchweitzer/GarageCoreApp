using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarageCoreApp
{
    internal class JsonGarageStorage
    {
        public static void storeGarageData(string storagePath, GarageData data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(storagePath, jsonString);
        }

        public static GarageData GetGarageData(string storagePath)
        {
            GarageData garageData = new GarageData();
            try
            {
                string jsonString = File.ReadAllText(storagePath);
                GarageData? parsedData = JsonSerializer.Deserialize<GarageData>(jsonString);

                if(parsedData != null)
                {
                    garageData = parsedData;
                }

               
                return garageData;

            }
            catch (FileNotFoundException e)
            {
                IOUtils.showLog("Allocating new storage");
                return garageData;
            }
            catch (Exception e)
            {
                IOUtils.showError(e);
                return garageData;
            }
        }
       

    }
}
