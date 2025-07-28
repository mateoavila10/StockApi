document.getElementById("login-form").addEventListener("submit", async (e) => {
  e.preventDefault();

  const nombreUsuario = document.getElementById("usuario").value;
  const contraseña = document.getElementById("contraseña").value;

  try {
    const response = await fetch("/api/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ NombreUsuario : nombreUsuario, Contraseña : contraseña }),
    });

    if (response.ok) {
      const data = await response.json();
      if (data.rol === "admin") {
        window.location.href = "./pages/Empleados.html"; // ✅ Corregido
      } else {
        window.location.href = "./pages/GestionProductos.html"; // ✅ Corregido
      }
    } else {
      document.getElementById("mensaje").textContent = "Usuario o contraseña incorrectos.";
    }
  } catch (error) {
    console.error("Error:", error);
    document.getElementById("mensaje").textContent = "No se pudo conectar con el servidor.";
  }
});
