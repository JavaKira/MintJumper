using System.IO;
using UnityEngine;

namespace IO
{
    public static class CampaignIO
    {
        private const string Extension = ".mcamp";
        private const string Directory = "Campaign/";
        
        public static void Save(CampaignData data)
        {
            var directory = new DirectoryInfo(Application.persistentDataPath + "/" + Directory);
            if (!directory.Exists)
                directory.Create();
            
            var name = "campaignSave";
            name += Extension;
            using var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Create);
            using var writer = new BinaryWriter(fileStream);
            writer.Write(data.GetData().Count);
            foreach (var pointData in data.GetData())
            {
                writer.Write(pointData.CampaignPointTitle);
                writer.Write(pointData.Completed);
            }
            
            fileStream.Close();
        }
        
        public static CampaignData Load()
        {
            var name = "campaignSave";
            name += Extension;
            using var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Open);
            using var reader = new BinaryReader(fileStream);
            var data = new CampaignData();
            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                var pointData = new CampaignPoint.CampaignPointData(reader.ReadString())
                {
                    Completed = reader.ReadBoolean()
                };
                
                data.PutData(pointData);
            }
            
            return data;
        }
    }
}