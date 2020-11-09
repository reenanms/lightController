# Light Controller
Light Controller é um projeto de exemplo de como controlar uma lâmpada via terminal e protocolo serial


## O protocolo
O protocolo é baseado em conexão serial onde um microcontrolador trabalha como servidor e troca mensagens com uma máquina cliente através da serial.
A troca de mensagens funciona da seguinte maneira:
-O cliente faz uma solicitação (request) para o microcontrolador (servidor);
-O servidor processa a solicitação;
-O servidor responde (response) o resultado do processamento da solicitação.
![Request e response](requestResponse.png)

### Mensagem de request
As mensagens de request possuem o seguinte modelo:
```
[COMANDO]:[PARAM_0],[PARAM_1],...,[PARAM_N];
```

Onde:
- COMANDO: é nome do comando a ser executado;
- PARAM_*: parâmetro de entrada do comando (número de parâmetros varia de acordo com o comando).

Importante:
- O carácter ponto e vírgula (";") determina o fim do comando;
- O carácter dois pontos (":") separa o nome do comando dos parametros;
- O carácter vírgula (",") determina a separação entre os parametros do comando.


### Mensagem de response
As mensagens de response possuem o seguinte modelo:
```
[STATUS]:[MENSAGEM];
```

Onde:
- STATUS: é o status do processamento do request: S para sucesso ou E para erro;
- MENSAGEM: mensagem com informações só status.

Importante:
- O carácter ponto e vírgula (";") determina o fim do comando;
- O carácter dois pontos (":") separa o status da mensagem.

### Lista de comandos possíveis:
```
ON:[NumeroPorta];
 ```
Comando para ligar a saída recebida por parâmetro.
Exemplo ligando saída 7: ON:7;
![Ligando saída 7](CodeSendingCommandON.gif)

```
 OFF:[NumeroPorta];
 ```
Comando para desligar a saída recebida por parâmetro.
Exemplo desligando saída 7: ON:7;
![Desligando saída 7](CodeSendingCommandOFF.gif)

## Interface de linha de comando (CLI)
Uma das maneiras de usar o protocolo é utilizar a interface de linha de comando (CLI). Ela abstrai o protocolo e disponibiliza para o usuário os comandos de forma mais amigável.
![CLI](CLI.gif)

### Lista de comandos
- q
- help
- turnOn [NumeroPorta]
- turnOff [NumeroPorta]
