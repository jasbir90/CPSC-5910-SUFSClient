using Amazon.S3;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Amazon.S3.Model;

namespace SUFS_ClientApplication
{
    public class S3Client
    {

        static string secretKey = "";
        static string accessKey = "";

        public long getBucketSize()
        {
            string bucketName = "wordcount-kaurj7";
            long bucketSize = -1;

            AmazonS3Config config1 = new AmazonS3Config();
            //config1.ServiceURL = "objects.dreamhost.com";

            AmazonS3Client s3Client = new AmazonS3Client(
                     accessKey, secretKey
                    );

            ListObjectsRequest request = new ListObjectsRequest();
            request.BucketName = bucketName;
            ListObjectsResponse response = s3Client.ListObjects(request);
            foreach (S3Object o in response.S3Objects)
            {
                if (o.BucketName == bucketName)
                    bucketSize = o.Size;
                //Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);

            }
            Console.WriteLine(bucketSize);
            return bucketSize;


        }
    }
}
