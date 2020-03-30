using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Tranq.Twitch.ChannelPoints.Core;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints.Repository
{
    public class FileRepository : IRepository
    {
        private readonly string folderPath;
        private const string PointRedemptionLogFileName = "RedeemedPoints.json";
        private const string RedemptionOptionsFileName = "RedemptionOptions.json";
        private const string ApplicationSettingsFileName = "ApplicationSettings.json";

        public FileRepository(string folderPath = "")
        {
            this.folderPath = folderPath;
        }

        private string FullFileName(string fileName) => folderPath != string.Empty ? Path.Combine(folderPath, fileName) : fileName;

        public void Save(PointRedemption pointRedemption)
        {
            EnsureFolderCreated();

            var existingRedemptions = new List<PointRedemption>();
            var fullPath = FullFileName(PointRedemptionLogFileName);
            if (File.Exists(fullPath))
            {
                var existingRedemptionsJson = File.ReadAllText(fullPath);
                existingRedemptions = JsonConvert.DeserializeObject<List<PointRedemption>>(existingRedemptionsJson);
            }

            existingRedemptions.Add(pointRedemption);

            var newJson = JsonConvert.SerializeObject(existingRedemptions);
            File.WriteAllText(fullPath, newJson);
        }

        public void Save(RedemptionOption redemptionOption)
        {
            EnsureFolderCreated();

            var existingOptions = new List<RedemptionOption>();
            var fullPath = FullFileName(RedemptionOptionsFileName);
            if (File.Exists(fullPath))
            {
                var RedemptionOptionsJson = File.ReadAllText(fullPath);
                existingOptions = JsonConvert.DeserializeObject<List<RedemptionOption>>(RedemptionOptionsJson);
            }

            var existingOption = existingOptions.Find(x => x.RewardName == redemptionOption.RewardName);
            if (existingOption != null)
                existingOptions.Remove(existingOption);

            existingOptions.Add(redemptionOption);

            var newJson = JsonConvert.SerializeObject(existingOptions);
            File.WriteAllText(fullPath, newJson);
        }

        public RedemptionOption GetRedemptionOption(string rewardName)
        {
            EnsureFolderCreated();

            var fullPath = FullFileName(RedemptionOptionsFileName);

            var existingOptions = new List<RedemptionOption>();
            if (File.Exists(fullPath))
            {
                var RedemptionOptionsJson = File.ReadAllText(fullPath);
                existingOptions = JsonConvert.DeserializeObject<List<RedemptionOption>>(RedemptionOptionsJson);
            }

            var result = existingOptions?.Find(x => x.RewardName == rewardName);
            if (result == null)
                return null;

            return result;
        }

        public void DeleteRedemptionOption(string rewardName)
        {
            EnsureFolderCreated();

            var fullPath = FullFileName(RedemptionOptionsFileName);

            var existingOptions = new List<RedemptionOption>();
            if (File.Exists(fullPath))
            {
                var RedemptionOptionsJson = File.ReadAllText(fullPath);
                existingOptions = JsonConvert.DeserializeObject<List<RedemptionOption>>(RedemptionOptionsJson);
            }

            var result = existingOptions?.Find(x => x.RewardName == rewardName);
            if (result != null)
                existingOptions.Remove(result);

            var newJson = JsonConvert.SerializeObject(existingOptions);
            File.WriteAllText(fullPath, newJson);
        }

        private void EnsureFolderCreated()
        {
            if (folderPath != string.Empty)
                Directory.CreateDirectory(folderPath);
        }

        public List<RedemptionOption> GetRedemptionOptions()
        {
            EnsureFolderCreated();

            var fullPath = FullFileName(RedemptionOptionsFileName);

            var existingOptions = new List<RedemptionOption>();
            if (File.Exists(fullPath))
            {
                var RedemptionOptionsJson = File.ReadAllText(fullPath);
                existingOptions = JsonConvert.DeserializeObject<List<RedemptionOption>>(RedemptionOptionsJson);
            }

            return existingOptions;
        }

        public ApplicationSettings GetSettings()
        {
            EnsureFolderCreated();
            var fullPath = FullFileName(ApplicationSettingsFileName);

            var existingSettings = new ApplicationSettings();
            if (File.Exists(fullPath))
            {
                var settingsJson = File.ReadAllText(fullPath);
                existingSettings = JsonConvert.DeserializeObject<ApplicationSettings>(settingsJson);
            }
            else
            {
                var json = JsonConvert.SerializeObject(existingSettings);
                File.WriteAllText(fullPath, json);

                return existingSettings;
            }

            return existingSettings;
        }
    }
}
