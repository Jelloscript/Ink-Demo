﻿using Amazon.S3;
using Amazon;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Services
{

    class MediaFileService
    {

        static string bucketName = ConfigService.uploadFileS3BucketName;
        static string subDirectoryInBucket = "C20/";
        //public bool sendMyFileToS3(string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        public static bool sendMyFileToS3(string localFilePath, string fileNameInS3)
        {
            // input explained :
            // localFilePath = the full local file path e.g. "c:\mydir\mysubdir\myfilename.zip"
            // bucketName : the name of the bucket in S3 ,the bucket should be alreadt created
            // subDirectoryInBucket : if this string is not empty the file will be uploaded to
            // a subdirectory with this name
            // fileNameInS3 = the file name in the S3

            // create an instance of IAmazonS3 class ,in my case i choose RegionEndpoint.EUWest1
            // you can change that to APNortheast1 , APSoutheast1 , APSoutheast2 , CNNorth1
            // SAEast1 , USEast1 , USGovCloudWest1 , USWest1 , USWest2 . this choice will not
            // store your file in a different cloud storage but (i think) it differ in performance
            // depending on your location
            IAmazonS3 client = AWSClientFactory.CreateAmazonS3Client(ConfigService.uploadFileS3AccessKey, ConfigService.uploadFileS3SecretKey, RegionEndpoint.USWest2);

            // create a TransferUtility instance passing it the IAmazonS3 created in the first step
            TransferUtility utility = new TransferUtility(client);
            // making a TransferUtilityUploadRequest instance
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            //if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            //{
            //    request.BucketName = bucketName; //no subdirectory just bucket name
            //}
            //else
            //{   // subdirectory and bucket name
            //    request.BucketName = bucketName + @"/" + subDirectoryInBucket;
            //}
            request.BucketName = ConfigService.uploadFileS3BucketName;// + @"/" + subDirectoryInBucket;
            request.Key = subDirectoryInBucket + fileNameInS3; //file name up in S3
            request.FilePath = localFilePath; //local file name
            request.ContentType = MimeMapping.GetMimeMapping(request.Key);
            utility.Upload(request); //commensing the transfer

            return true; //indicate that the file was sent
        }
    }
}

