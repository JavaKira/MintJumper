using System.IO;
using UnityEngine;

namespace IO
{
    public static class EquipmentIO
    {
        private const string Extension = ".equi";
        private const string Directory = "Campaign/";
        
        public static void Save(EquipmentData data)
        {
            var directory = new DirectoryInfo(Application.persistentDataPath + "/" + Directory);
            if (!directory.Exists)
                directory.Create();
            
            var name = "equipment";
            name += Extension;
            using var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Create);
            using var writer = new BinaryWriter(fileStream);
            writer.Write(data.GetUnlockedWeapons().Count);
            foreach (var unlockedWeapon in data.GetUnlockedWeapons())
            {
                writer.Write(unlockedWeapon);
            }
            
            writer.Write(data.GetChosedWeapon() != null ? data.GetChosedWeapon().name : "");
        }
        
        public static EquipmentData Load()
        {
            var name = "equipment";
            name += Extension;
            if (!File.Exists(Application.persistentDataPath + "/" + Directory + name))
                Save(new EquipmentData());
            
            using var fileStream = new FileStream(Application.persistentDataPath + "/" + Directory + name, FileMode.Open);
            using var reader = new BinaryReader(fileStream);
            var data = new EquipmentData();
            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                data.UnlockWeapon(reader.ReadString());
            }
            
            
            data.ChoseWeapon(Weapon.Weapon.GetByName(reader.ReadString()));
            return data;
        }
    }
}