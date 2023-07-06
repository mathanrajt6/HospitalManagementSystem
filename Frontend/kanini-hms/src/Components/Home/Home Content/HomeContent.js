import './HomeContent.css'
import cover from '../../../Asset/cover-page.jpg'
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';
function HomeContent()
{

    const [bmi,setBMI] = useState(
        {
            "weight":0,
            "height":0
        }
    );

    const [calcBMI,setCalcBMI] = useState();
   
    const  calculateBMI=()=> {
        
            if(validateHeight()  && validateWeight())
            {
                const heightInMeters = bmi.height / 100;
                const calculatedBMI = bmi.weight / (heightInMeters * heightInMeters);
                const roundedBMI = calculatedBMI.toFixed(2);
                setCalcBMI(roundedBMI);
            }
         
      
      }

      const getBMIClass = () => {
        if (calcBMI < 18.5) {
          return "underweight";
        } else if (calcBMI >= 18.5 && calcBMI < 25) {
          return "normal";
        } else if (calcBMI >= 25 && calcBMI < 30) {
          return "overweight";
        } else {
          return "obese";
        }
      };
      
      const validateHeight=()=>
      {
        var height = (bmi.height >0);
        if(height)
        {
            document.getElementById('height-validate').innerHTML="";
            document.body.getElementsByClassName('bmi-height')[0].classList.add('valid');
            document.body.getElementsByClassName('bmi-height')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('height-validate').innerHTML="Height should be greater than 0";
            document.body.getElementsByClassName('bmi-height')[0].classList.remove('valid');
            document.body.getElementsByClassName('bmi-height')[0].classList.add('invalid');
        }
        return height;
      }

      const validateWeight=()=>
      {
        var weight = (bmi.weight >0);
        if(weight)
        {
            document.getElementById('weight-validate').innerHTML="";
            document.body.getElementsByClassName('bmi-weight')[0].classList.add('valid');
            document.body.getElementsByClassName('bmi-weight')[0].classList.remove('invalid');
        }
        else{
            document.getElementById('weight-validate').innerHTML="Weight should be greater than 0";
            document.body.getElementsByClassName('bmi-weight')[0].classList.remove('valid');
            document.body.getElementsByClassName('bmi-weight')[0].classList.add('invalid');
        }
        return weight;
      }

    
    useEffect(() => {
        const healthyTips = [
                    "Stay hydrated by drinking enough water throughout the day.",
                    "Eat a balanced diet that includes a variety of fruits, vegetables, whole grains, lean proteins, and healthy fats.",
                    "Limit processed and sugary foods, opting for natural and wholesome options instead.",
                    "Control portion sizes to maintain a healthy weight and prevent overeating.",
                    "Engage in regular physical activity or exercise for at least 30 minutes a day.",
                    "Get enough sleep to support overall health and well-being.",
                    "Practice stress management techniques, such as deep breathing, meditation, or yoga.",
                    "Limit alcohol consumption and avoid smoking or using tobacco products.",
                    "Prioritize mental health by seeking support, engaging in hobbies, and taking breaks when needed.",
                    "Maintain good personal hygiene, including regular handwashing and dental care.",
                    "Incorporate mindful eating habits, such as eating slowly and savoring each bite.",
                    "Include probiotics in your diet to support a healthy gut microbiome.",
                    "Limit sodium intake by avoiding excessive salt in your meals.",
                    "Choose healthier cooking methods, such as steaming, grilling, or baking, over frying.",
                    "Practice proper food safety measures, including storing, handling, and cooking food safely.",
                    "Stay socially connected with friends and loved ones to promote emotional well-being.",
                    "Protect your skin from the sun by wearing sunscreen and avoiding excessive sun exposure.",
                    "Stay active throughout the day by taking breaks from sitting and incorporating movement into your routine.",
                    "Incorporate relaxation techniques, such as deep breathing or progressive muscle relaxation, to reduce stress.",
                    "Stay updated with routine health check-ups and screenings to detect and prevent any potential health issues."
                  ];
        
        const randomIndex = Math.floor(Math.random() * healthyTips.length);
        const randomTip = healthyTips[randomIndex];
    
        toast.info("Health Tip of the Day", {
          position: toast.POSITION.BOTTOM_RIGHT
        });
    
        toast.info(randomTip, {
          position: toast.POSITION.BOTTOM_RIGHT
        });
      }, []);
      
     
      
    return(
        <div className="home-content">
            <div className="">
                <div className='home-content-image-box'>
                    {/* {"'"+randomTip+"'"} */}
                    <h2>
                        Welcome!!
                    </h2>
                    <label>
                        Are you fit check you BMI
                    </label>
                    <div className='home-bmi-item'>
                        <input type='number'   className="bmi-height"  placeholder="Enter your Height in mts" value={bmi.height==0 ? "":bmi.height}
                            onChange={(event)=>setBMI({...bmi,"height":event.target.value})} onBlur={validateHeight}
                        
                        /> 
                        <span id='height-validate'></span>

                    </div>
                    <div className='home-bmi-item'>
                            <input type='number ' className='bmi-weight'
                        onChange={(event)=>setBMI({...bmi,"weight":event.target.value})}  placeholder="Enter your Height in Kgs"  value={bmi.weight==0 ? "":bmi.weight  }
                        onBlur={validateWeight}
                        ></input>
                        <span id='weight-validate'></span>

                    </div>

                  
                    <div className='home-bmi-item'>
                        <label>  BMI Value</label>
                        <p className={`bmi-result ${getBMIClass()}`}>
                        {calcBMI}
                        </p>
                        <span id='bmi-validate'></span>

                    </div>

                    <div className='home-bmi-item'>
                        <button className='bmi-btn' onClick={calculateBMI}> Calculate BMI </button>
                    </div>
                </div>
            </div>
            
        </div>
    );
}

export default HomeContent;