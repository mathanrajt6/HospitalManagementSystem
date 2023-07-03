import './HomeContent.css'
import cover from '../../../Asset/cover-page.jpg'
function HomeContent()
{

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
      
    return(
        <div className="home-content">
            <div className="">
                <div className='home-content-image-box'>
                    {"'"+randomTip+"'"}
                </div>
            </div>
            
        </div>
    );
}

export default HomeContent;