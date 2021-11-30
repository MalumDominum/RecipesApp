using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using System.Linq;

namespace BusinessLogicLayer.Infrastructure
{
    public class PortionDistributor : IPortionDistributor
    {
        public DishPortionDTO ChangePortionSize(DishPortionDTO dishPortion, double coefficient)
        {
            if (dishPortion is null)
                throw new ArgumentNullException(nameof(dishPortion));

            if (coefficient <= 0)
                throw new ArgumentException(nameof(coefficient) + " must be greater than zero");

            var result = new DishPortionDTO
            {
                Cost = dishPortion.Cost * coefficient,
                Weight = dishPortion.Weight * coefficient,
                DishId = dishPortion.DishId
            };
            if (dishPortion.Calories is not null)
                result.Calories = dishPortion.Calories * coefficient;

            if (dishPortion.Proteins is not null)
                result.Proteins = dishPortion.Proteins * coefficient;

            if (dishPortion.Fats is not null)
                result.Fats = dishPortion.Fats * coefficient;

            if (dishPortion.Carbs is not null)
                result.Carbs = dishPortion.Carbs * coefficient;

            return result;
        }

        public List<DishPortionDTO> DistributePortions(DishPortionDTO dishPortion, double[] coefficients)
        {
            if (coefficients is null)
                throw new ArgumentNullException(nameof(coefficients));

            var dishPortions = new List<DishPortionDTO>
            {
                dishPortion
            };
            foreach (var c in coefficients)
                dishPortions.Add(ChangePortionSize(dishPortion, c));

            return dishPortions.OrderBy(x => x.Cost).ToList();
        }
    }
}
