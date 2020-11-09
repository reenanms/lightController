const char CommandSeparator = ':';
const char ParamsSeparator = ',';
const char EndChar = ';';

const int NumberOfPorts = 2;
const int ValidPorts[NumberOfPorts] = { 7, 8 };


void turnOn(int port)
{
  pinMode(port, OUTPUT);
  digitalWrite(port, LOW);
}

void turnOff(int port)
{
  pinMode(port, OUTPUT);
  digitalWrite(port, HIGH);
}

void sendSerialCommand(String command)
{
  Serial.print(command);
  Serial.print(EndChar);
}

bool isValidPort(int port)
{
  for(int i = 0; i < NumberOfPorts; i++)
  {
    if (ValidPorts[i] == port)
      return true;
  }

  return false;
}

bool getParams(String rawCommand, int commandSeparatorIndex, int numberOfParams, String* outParams)
{
  int afterIndex = commandSeparatorIndex;
  for(int i = 0; i < numberOfParams; i++)
  {
     int startIndex = afterIndex+1;
     afterIndex = rawCommand.indexOf(ParamsSeparator, startIndex);
     
     //apenas o ultimo parametro esperado pode não ter o separador(",")
     if (afterIndex == -1 && i != numberOfParams-1) return false; 
     
     int endIndex = afterIndex != -1 ? afterIndex : rawCommand.length()-1;
     String param = rawCommand.substring(startIndex, endIndex+1);
     outParams[i] = param;
  }

  return true;
}

bool tryGetPort(String rawCommand, int commandSeparatorIndex, int numberOfParams, int * outPort)
{
    String params[1];
    if (!getParams(rawCommand, commandSeparatorIndex, 1, params))
    {
      sendSerialCommand("E:Parametro(s) invalido(s)");
      return false;
    }

    int port = params[0].toInt();
    if (!isValidPort(port))
    {
      sendSerialCommand("E:Porta invalida");
      return false;
    }

    *outPort = port;
    return true;
}

void runCommand(String rawCommand)
{
  int commandSeparatorIndex = rawCommand.indexOf(CommandSeparator);
  String commandName = rawCommand.substring(0, commandSeparatorIndex);

  if (commandName ==  "ON")
  {
    int port;
    if(!tryGetPort(rawCommand, commandSeparatorIndex, 1, &port))
      return;
    
    turnOn(port);
    sendSerialCommand("S:OK");
    return;
  }
  
  if (commandName == "OFF")
  {
    int port;
    if(!tryGetPort(rawCommand, commandSeparatorIndex, 1, &port))
      return;
    
    turnOff(port);
    sendSerialCommand("S:OK");
    return;
  }

  sendSerialCommand("E:Comando invalido");
}

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  /*
  Comandos suportados:
    ON:[OUTPUT_PORT_NUMBER]
    OFF:[OUTPUT_PORT_NUMBER]
  */
  
  if (Serial.available())
  {
    String rawCommand = Serial.readStringUntil(EndChar);
    runCommand(rawCommand);
  }
}
