const serviceSelect = document.getElementById('serviceSelect');
const chatForm = document.getElementById('chatForm');
const messageInput = document.getElementById('messageInput');
const messages = document.getElementById('messages');

function appendMessage(text, type) {
  const div = document.createElement('div');
  div.className = `message ${type}`;
  div.textContent = text;
  messages.appendChild(div);
  messages.scrollTop = messages.scrollHeight;
}

async function loadServices() {
  const response = await fetch('/api/services');
  const services = await response.json();

  services.forEach((service) => {
    const option = document.createElement('option');
    option.value = service.name;
    option.textContent = `${service.name} - ${service.description}`;
    serviceSelect.appendChild(option);
  });
}

chatForm.addEventListener('submit', async (event) => {
  event.preventDefault();

  const service = serviceSelect.value;
  const message = messageInput.value.trim();

  if (!message) return;

  appendMessage(`You (${service}): ${message}`, 'user');
  messageInput.value = '';

  const response = await fetch('/api/chat', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ service, message })
  });

  const data = await response.json();

  if (!response.ok) {
    appendMessage(`Error: ${data.error ?? 'Unknown error'}`, 'bot');
    return;
  }

  appendMessage(`Bot: ${data.output}`, 'bot');
});

loadServices().catch((error) => {
  appendMessage(`Unable to load services: ${error.message}`, 'bot');
});
