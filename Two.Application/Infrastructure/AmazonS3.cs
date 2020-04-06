using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Boxters.Application.Infrastructure
{
    public class AmazonS3 : AmazonS3Client
    {
        private const string awsAccessKeyId = "AKIA4567YJWRZDARZONO";
        private const string awsSecretAccessKey = "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";
        private static readonly RegionEndpoint region = RegionEndpoint.EUCentral1;
        private const string bucketName = "two-bros";

        public AmazonS3() : base(awsAccessKeyId, awsSecretAccessKey, region)
        {
        }

        public async Task UploadFoodImage(IFormFile file, string filename)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                await PutObjectAsync(new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = $"images/food/{filename}",
                    InputStream = ms
                });
            }
        }

        public async Task DeleteFoodImageAsync(string ImagePath)
        {
            await DeleteObjectAsync(new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = ImagePath
            });
        }

        public string GetRandomFileNameWithPrefix(string filename, int maxRandom, int multiply)
        {
            Random random = new Random();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < multiply; i++)
            {
                stringBuilder.Append(random.Next(0, maxRandom));
            }

            stringBuilder.Append($"_{filename}");

            return stringBuilder.ToString();
        }
    }
}
