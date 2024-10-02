namespace Proyecto_Practica_05_.Interfaces
{
    public interface IMapper<Input, Output>
    {
        Output Set(Input entity);
        List<Output> Set(List<Input> entity);
        Input Get(Output entity);
        List<Input> Get(List<Output> entity);
    }
}
