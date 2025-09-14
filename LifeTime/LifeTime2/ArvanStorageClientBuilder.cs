using Amazon.S3;
using Microsoft.Extensions.Options;

namespace LifeTime2; 

public class ArvanStorageClientBuilder
{
    private readonly ArvanStorageOptions _options;


    public ArvanStorageClientBuilder(IOptions<ArvanStorageOptions> options)
    {
        _options = options.Value ?? throw new NullReferenceException($"{nameof(ArvanStorageOptions)} is not fed.");
    }
    public AmazonS3Client Build()
    {
        var ArvanStorage_AccessKey = _options.AccessKey;
        var ArvanStorage_SecretKey = _options.SecretKey;
        var ArvanStorage_ServerApi = _options.ServerApi;

        if (ArvanStorage_ServerApi?.Length == 0 || ArvanStorage_AccessKey?.Length == 0 ||
            ArvanStorage_SecretKey?.Length == 0)
            throw new Exception("ArvanStorage configurations not found.");

        return new AmazonS3Client(ArvanStorage_AccessKey, ArvanStorage_SecretKey,
            new AmazonS3Config
            {
                SignatureMethod = Amazon.Runtime.SigningAlgorithm.HmacSHA256,
                ServiceURL = ArvanStorage_ServerApi,
                ForcePathStyle = true,
            });
    }
}
