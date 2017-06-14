using System;
using System.IO;
using Sandbox.Web.Classes;
using Amazon.S3.Model;
using Amazon.S3;

namespace Sandbox.Web.Services
{
    public class StorageService : BaseService
    {
        private static string bucketName = ServiceConfig.AwsBucket + "/" + ServiceConfig.AwsFolder;

        public static string UploadBlob(Stream streamIn, string imageNameIn)
        {
            string keyName = imageNameIn;
            Stream inputStream = streamIn;
            IAmazonS3 client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2);

            string message = string.Empty;

            try
            {
                PutObjectRequest request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = keyName,
                    InputStream = inputStream
                };
                PutObjectResponse response2 = client.PutObject(request);
                //return Request.CreateResponse(statusCode, response2);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {

                if (amazonS3Exception.ErrorCode != null &&
                   (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                   ||
                   amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    message = "Check the provided AWS Credentials. \n For service sign up go to http://aws.amazon.com/s3";
                    //response = new ErrorResponse(amazonS3Exception.ErrorCode);
                }
                else
                {
                    message = String.Format("Error occurred. Message:'{0}' when writing an object", amazonS3Exception.Message);
                    //response = new ErrorResponse(amazonS3Exception.Message);
                }

            }
            return message;
        }

        public static string UploadFile(string filePathIn, string fileNameIn)
        {
            IAmazonS3 client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2);

            string message = string.Empty;

            try
            {
                PutObjectRequest request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = fileNameIn,
                    FilePath = filePathIn
                };
                PutObjectResponse response2 = client.PutObject(request);
                //return Request.CreateResponse(statusCode, response2);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {

                if (amazonS3Exception.ErrorCode != null &&
                   (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                   ||
                   amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    message = "Check the provided AWS Credentials. \n For service sign up go to http://aws.amazon.com/s3";
                    //response = new ErrorResponse(amazonS3Exception.ErrorCode);
                }
                else
                {
                    message = String.Format("Error occurred. Message:'{0}' when writing an object", amazonS3Exception.Message);
                    //response = new ErrorResponse(amazonS3Exception.Message);
                }

            }
            return message;
        }

        public static void DeleteObject(string key)
        {

            IAmazonS3 client;

            using (client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {
                DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = key
                };
                client.DeleteObject(deleteObjectRequest);
            }
        }

        public static void ReadObjectData(string key)
        {
            //string folderName = "~/uploadFiles";
            string dest = @"C:\SF.Code\C22\Sabio.Web\uploadFiles\" + key;
            IAmazonS3 client;
            using (client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = key
                };

                using (GetObjectResponse response = client.GetObject(request))
                {

                    //string dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), key);
                    if (!File.Exists(dest))
                    {
                        response.WriteResponseStreamToFile(dest);
                    }
                }
            }
        }

        //string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\downloads";
        //string responseBody = "";
        //    IAmazonS3 client;

        //    using (client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2))
        //    {
        //        GetObjectRequest request = new GetObjectRequest
        //        {
        //            BucketName = bucketName,
        //            Key = key
        //        };

        //        using (GetObjectResponse response = client.GetObject(request))
        //        using (Stream responseStream = response.ResponseStream)
        //        using (StreamReader reader = new StreamReader(responseStream))
        //        {
        //            string title = response.Metadata["x-amz-meta-title"];
        //            Console.WriteLine("The object's title is {0}", title);
        //            responseBody = reader.ReadToEnd();
        //            byte[] newBytes = Convert.FromBase64String(responseBody);

        //        }
        //    }
        //    return responseBody;

        //http://docs.ceph.com/docs/jewel/radosgw/s3/csharp/
        //GetObjectRequest request = new GetObjectRequest();
        //request.BucketName = "my-new-bucket";
        //request.Key = "perl_poetry.pdf";
        //GetObjectResponse response = client.GetObject(request);
        //response.WriteResponseStreamToFile("C:\\Users\\larry\\Documents\\perl_poetry.pdf");


        ////public S3Object Get(string key) {

        ////S3Object s3Object = null;
        //IAmazonS3 client;
        //using (client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
        //{
        //    GetObjectRequest request = new GetObjectRequest
        //    {
        //        BucketName = bucketName,
        //        Key = key
        //    };

        //    using (GetObjectResponse response = client.GetObject(request))
        //    {
        //        //response.WriteResponseStreamToFile()
        //        return response.ResponseStream;

        //    }


        //}
        //}
        //IAmazonS3 client;

        //var filePath = @"SiteConfig.GetUrlForFile("")";

        //using (client = new AmazonS3Client(Amazon.RegionEndpoint.USWest2))
        //{
        //    GetObjectRequest request = new GetObjectRequest
        //    {
        //        BucketName = bucketName,
        //        Key = key
        //    };

        //    using (GetObjectResponse response = client.GetObject(request))
        //    {
        //        if (!File.Exists(filePath))
        //        {
        //            response.WriteResponseStreamToFile(filePath);
        //        }
        //    }
        //}



        // Issue request and remember to dispose of the response


        //public static string ReadObjectData(string key)
        //{

        //    string responseBody = "";
        //    IAmazonS3 client;

        //    using (client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
        //    {
        //        GetObjectRequest request = new GetObjectRequest
        //        {
        //            BucketName = bucketName,
        //            Key = key
        //        };

        //        using (GetObjectResponse response = client.GetObject(request))
        //        using (Stream responseStream = response.ResponseStream)
        //        using (StreamReader reader = new StreamReader(responseStream))
        //        {
        //            //string title = response.Metadata["x-amz-meta-title"];
        //            //Console.WriteLine("The object's title is {0}", title);
        //            responseBody = reader.ReadToEnd();
        //        }
        //    }
        //    return responseBody;
        //}
    }
}