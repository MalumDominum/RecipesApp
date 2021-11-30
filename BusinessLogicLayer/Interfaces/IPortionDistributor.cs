using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPortionDistributor
    {
        public DishPortionDTO ChangePortionSize(DishPortionDTO dishPortion, double coefficient);

        public List<DishPortionDTO> DistributePortions(DishPortionDTO dishPortion, double[] coefficients);
    }
}
