export const addToCart = async (productId, quantity = 1) => {
  try {
    const response = await fetch("/api/cart/add", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ productId, quantity }),
    });
    const data = await response.json();
    
    if (data.success) {
      showNotification("Đã thêm vào giỏ hàng!", "success");
      return data.cartCount;
    } else {
      showNotification("Có lỗi xảy ra!", "error");
    }
  } catch (error) {
    console.error("Error:", error);
    showNotification("Có lỗi xảy ra!", "error");
  }
}

export const showNotification = (message, type = "success") => {
  // Using SweetAlert2
  Swal.fire({
    text: message,
    icon: type,
    toast: true,
    position: "top-end",
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
  });
}

// Scroll handlers
export const handleScroll = () => {
  const navbar = document.querySelector(".navbar");
  const currentScroll = window.pageYOffset;

  if (currentScroll > 50) {
    navbar.classList.add("scrolled");
    navbar.style.background = "rgba(255,255,255,0.98)";
  } else {
    navbar.classList.remove("scrolled");
    navbar.style.background = "rgba(255,255,255,0.95)";
  }
}

// Parallax effect
export const handleParallax = () => {
  const scrolled = window.pageYOffset;
  const heroImages = document.querySelectorAll(".carousel-item img");
  const heroCaptions = document.querySelectorAll(".carousel-caption");

  heroImages.forEach((img) => {
    img.style.transform = `translateY(${scrolled * 0.3}px)`;
  });

  heroCaptions.forEach((caption) => {
    caption.style.transform = "translateY(50%)";
    caption.style.opacity = 1 - scrolled * 0.002;
  });
}
