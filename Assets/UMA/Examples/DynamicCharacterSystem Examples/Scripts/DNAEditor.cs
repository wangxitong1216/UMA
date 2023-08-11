using UnityEngine;
using UnityEngine.UI;

namespace UMA.CharacterSystem
{
    public class DNAEditor : MonoBehaviour
    {
        string _DNAName;
        int _Index;
        UMADnaBase _Owner;   // different DNA 
        DynamicCharacterAvatar _Avatar;
        float _InitialValue;
        DNARangeAsset _dnr;

        public Slider ValueSlider;
        public Text Label;

        // Use this for initialization
        void Start()
        {
            ValueSlider.value = _InitialValue;

            //Label.text = _DNAName;
            switch (_DNAName)
            {
                case "Arm Length":
                    Label.text = "臂长";
                    break;
                case "Arm Width":
                    Label.text = "臂宽";
                    break;
                case "Belly":
                    Label.text = "肚子";
                    break;
                case "Breast Size":
                    Label.text = "胸部大小";
                    break;
                case "Feet Size":
                    Label.text = "脚部大小";
                    break;
                case "Forearm Length":
                    Label.text = "前臂长";
                    break;
                case "Forearm Width":
                    Label.text = "前臂宽";
                    break;
                case "Gluteus Size":
                    Label.text = "臀肌大小";
                    break;
                case "Hands Size":
                    Label.text = "手的大小";
                    break;
                case "Leg Separation":
                    Label.text = "腿部分离";
                    break;
                case "Height":
                    Label.text = "身高";
                    break;
                case "Legs Size":
                    Label.text = "腿的大小";
                    break;
                case "Lower Muscle":
                    Label.text = "下腿肌";
                    break;
                case "Lower Weight":
                    Label.text = "下腿宽";
                    break;
                case "Mouth Size":
                    Label.text = "嘴部大小";
                    break;
                case "Neck Thickness":
                    Label.text = "脖子粗细";
                    break;
                case "Upper Muscle":
                    Label.text = "上方肌肉";
                    break;
                case "Upper Weight":
                    Label.text = "上方宽度";
                    break;
                case "Waist":
                    Label.text = "腰部大小";
                    break;
                default:
                    break;
            }
        }

        public void Initialize(string name, int index, UMADnaBase owner, DynamicCharacterAvatar avatar, float currentval)
        {
            _DNAName = name;
            _Index = index;
            _Owner = owner;
            _Avatar = avatar;
            _InitialValue = currentval;
            Debug.Log(_DNAName);
            //DNARangeAsset[] dnaRangeAssets = avatar.activeRace.data.dnaRanges;
            //foreach (DNARangeAsset d in dnaRangeAssets)
            //{
            //    if (d.ContainsDNARange(_Index, _DNAName))
            //    {
            //        _dnr = d;
            //        return;
            //    }
            //}
        }
        
        public void ChangeValue(float value)
        {
            if (_dnr == null) //No specified DNA Range Asset for this DNA
            {
                Debug.Log(gameObject.name);
                _Owner.SetValue(_Index, value);
                _Avatar.ForceUpdate(true, false, false);
                return;
            }

            //if (_dnr.ValueInRange(_Index, value))
            //{
            //    _Owner.SetValue(_Index, value);
            //    _Avatar.ForceUpdate(true, false, false);
            //    return;
            //}
            //else
            //{
            //    //Debug.LogWarning ("DNA Value out of range!");
            //}
        }
    }
}
