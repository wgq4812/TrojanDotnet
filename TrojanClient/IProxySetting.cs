namespace TrojanClient
{
    public interface IProxySetting
    {
      void  SetPacProxy(string data);
        
      void  SetGlobalProxy(string data);


      void RemoveSetting();

    }
}