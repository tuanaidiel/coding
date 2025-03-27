window.onload = () => {
    startHeartRain(); // Call the function when the page loads
  };

function startHeartRain() {
    const heartContainer = document.getElementById("heart-container");
    if (!heartContainer) return;
    
    setInterval(() => {
        let heart = document.createElement("div");
        heart.classList.add("heart");
        heart.innerHTML = "❤️";
        heart.style.position = "absolute";
        heart.style.left = Math.random() * window.innerWidth + "px";
        heart.style.top = "-20px"; // Ensure it starts above the screen
        heart.style.fontSize = "24px";
        heart.style.animation = "fall 5s linear";
        heartContainer.appendChild(heart);
  
        setTimeout(() => {
            heart.remove();
        }, 5000);
    }, 300);
  }