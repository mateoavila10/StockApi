document.getElementById("product-form").addEventListener("submit", async (e) => {
  e.preventDefault();

  const nombre = document.getElementById("nombre").value;
  const stock = parseInt(document.getElementById("stock").value);
  const precio = parseFloat(document.getElementById("precio").value);

  const producto = { nombre, stock, precio };

  try {
    const response = await fetch("http://localhost:5100/producto", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(producto)
    });

    if (response.ok) {
      document.getElementById("mensaje").textContent = "Producto agregado exitosamente.";
      document.getElementById("product-form").reset();
    } else {
      document.getElementById("mensaje").textContent = "Error al agregar producto.";
    }
  } catch (error) {
    console.error("Error al enviar:", error);
    document.getElementById("mensaje").textContent = "No se pudo conectar con el servidor.";
  }
});