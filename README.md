# Unity 3D Game Project

Este proyecto es un juego en 3D desarrollado en Unity. A continuación, se describen los archivos principales que componen el proyecto.

## Archivos Principales

### 1. `CamaraPrimerNivel.cs`
Este script controla la cámara en el primer nivel del juego. La cámara sigue al jugador manteniendo un offset constante.

- **Variables:**
  - `public GameObject player`: El objeto del jugador que la cámara seguirá.
  - `private Vector3 offset`: La distancia entre la cámara y el jugador.

- **Métodos:**
  - `void Start()`: Calcula el offset inicial entre la cámara y el jugador.
  - `void LateUpdate()`: Actualiza la posición de la cámara para seguir al jugador.

### 2. `CameraScript.cs`
Este script controla la cámara principal del juego, permitiendo que siga al jugador y que rote horizontalmente basándose en la entrada del usuario.

- **Variables:**
  - `public GameObject player`: El objeto del jugador que la cámara seguirá.
  - `private Vector3 offset`: La distancia entre la cámara y el jugador.

- **Métodos:**
  - `void Start()`: Calcula el offset inicial y oculta el cursor.
  - `void LateUpdate()`: Actualiza la posición de la cámara y permite la rotación horizontal basada en la entrada del usuario.

### 3. `NewEnemyMovement.cs`
Este script controla el movimiento de los enemigos utilizando el sistema de navegación `NavMesh` de Unity.

- **Variables:**
  - `public Transform player`: El transform del jugador que el enemigo seguirá.
  - `private NavMeshAgent navMeshAgent`: El componente `NavMeshAgent` que controla el movimiento del enemigo.

- **Métodos:**
  - `void Start()`: Inicializa el `NavMeshAgent`.
  - `void Update()`: Actualiza el destino del enemigo para que siga al jugador.

### 4. `PickUp.cs`
Este script controla la rotación de los objetos recogibles en el juego.

- **Métodos:**
  - `void Update()`: Rota el objeto en el eje Y para dar un efecto visual de que está girando.

### 5. `player.cs`
Este script controla el comportamiento del jugador, incluyendo el movimiento, las colisiones, y la interacción con objetos y enemigos.

- **Variables:**
  - `public GameObject camara2`, `camara`, `camra3`: Diferentes cámaras para los niveles.
  - `public int requiredPickups`: Número de objetos recogibles necesarios para desbloquear una pared.
  - `public GameObject wall`, `wall2`, `muro1`: Paredes que pueden ser desbloqueadas.
  - `private Animator estados`: Controla las animaciones del jugador.
  - `public string estadoActual`: El estado actual del jugador (primer, segundo o tercer nivel).

- **Métodos:**
  - `void Start()`: Inicializa el jugador y las cámaras.
  - `void OnCollisionEnter(Collision collision)`: Maneja las colisiones con enemigos.
  - `void OnMove(InputValue movementValue)`: Captura la entrada de movimiento del jugador.
  - `void SetCountText()`: Actualiza el texto de la interfaz con el número de objetos recogidos.
  - `void UnlockWall()`: Desbloquea una pared cuando se recogen suficientes objetos.
  - `void OnTriggerEnter(Collider other)`: Maneja las colisiones con objetos recogibles y portales.
  - `void cambiarCamara()`: Cambia entre las cámaras según el nivel actual.

### 6. `PortalFuego.cs`
Este script controla el comportamiento del portal de fuego, que teletransporta al jugador a una nueva posición.

- **Métodos:**
  - `void OnCollisionEnter(Collision collision)`: Teletransporta al jugador cuando colisiona con el portal.

### 7. `script_subida.cs`
Este script controla un objeto que, al colisionar con el jugador, le aplica una fuerza hacia arriba, simulando una "subida" o impulso vertical.

- **Variables:**
  - `public float propulsion = 150.0f`: La fuerza de propulsión aplicada al jugador.

- **Métodos:**
  - `void OnCollisionEnter(Collision collision)`: Aplica una fuerza hacia arriba al jugador cuando colisiona con el objeto.

## Instrucciones de Uso

1. **Cámara**: La cámara sigue al jugador automáticamente. En `CameraScript.cs`, la cámara también puede rotar horizontalmente basándose en la entrada del usuario.
2. **Enemigos**: Los enemigos siguen al jugador utilizando el sistema de navegación `NavMesh`.
3. **Objetos Recogibles**: Los objetos recogibles rotan en el eje Y para dar un efecto visual.
4. **Jugador**: El jugador puede moverse, recoger objetos, y desbloquear paredes. También puede cambiar de nivel al interactuar con portales.
5. **Portales**: Los portales teletransportan al jugador a una nueva posición cuando colisionan con él.
6. **Subida**: El objeto con el script `script_subida.cs` aplica una fuerza hacia arriba al jugador cuando colisiona con él, simulando un impulso vertical.
