namespace BusinessLogicLayer.DTOs;

public class OrderDTO
{
    public int Id { get; set; }

    public string CustomerName { get; set; }

    public DateTime RequestTime { get; set; }

    public DateTime? ServingTime { get; set; }
}
