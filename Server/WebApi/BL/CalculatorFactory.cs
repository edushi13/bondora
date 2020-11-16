using WebApi.BL.Calculators;
using WebApi.Models;

namespace WebApi.BL
{
    public class CalculatorFactory
    {
        private HeavyCalculator _heavyCalculator;
        private HeavyCalculator HeavyCalculator
        {
            get
            {
                if(_heavyCalculator == null)
                {
                    _heavyCalculator = new HeavyCalculator();
                }
                return _heavyCalculator;
            }
        }

        private RegularCalculator _regularCalculator;
        private RegularCalculator RegularCalculator
        {
            get
            {
                if (_regularCalculator == null)
                {
                    _regularCalculator = new RegularCalculator();
                }
                return _regularCalculator;
            }
        }

        private SpecializedCalculator _specializedCalculator;
        private SpecializedCalculator SpecializedCalculator
        {
            get
            {
                if (_specializedCalculator == null)
                {
                    _specializedCalculator = new SpecializedCalculator();
                }
                return _specializedCalculator;
            }
        }

        public ICalculator GetCalculator(EquipmentType type)
        {
            ICalculator calc = null;
            switch (type)
            {
                case EquipmentType.Heavy:
                    calc = HeavyCalculator;
                    break;

                case EquipmentType.Regular:
                    calc = RegularCalculator;
                    break;

                case EquipmentType.Specialized:
                    calc = SpecializedCalculator;
                    break;
            }
            return calc;
        }
    }
}
