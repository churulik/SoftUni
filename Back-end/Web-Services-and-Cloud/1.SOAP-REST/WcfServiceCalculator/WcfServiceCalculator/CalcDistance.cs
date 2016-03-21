using System.ServiceModel;


namespace WcfServiceCalculator
{
    
    [ServiceContract]
    public interface IServiceCalculator
    {
        [OperationContract]
        double CalcDistance(int startX, int startY, int endX, int endY);
    }
}
