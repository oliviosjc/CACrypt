# Combat Arms Decrypt and Encrypt TXT Files

Aplicação Windows Forms para criptografar e descriptografar arquivos de texto usando o algoritmo TwoFish. Desenvolvido por Olívio Rodrigues.

## Índice
- [Recursos](#recursos)
- [Requisitos](#requisitos)
- [Guia de Instalação](#guia-de-instalação)
- [Como Executar](#como-executar)
- [Como Usar](#como-usar)
- [Solução de Problemas](#solução-de-problemas)

## Recursos

- ✅ Criptografar e descriptografar arquivos TXT usando algoritmo TwoFish
- ✅ Descriptografia em lote de múltiplos arquivos
- ✅ Interface gráfica amigável
- ✅ Barra de progresso para operações
- ✅ Visualizar conteúdo descriptografado antes de salvar
- ✅ Logs detalhados das operações

## Requisitos

- Windows 10 ou Windows 11
- .NET 6.0 Runtime (o aplicativo irá orientá-lo a instalar)
- Pelo menos 100MB de espaço livre em disco

## Guia de Instalação

### Passo 1: Verificar se o .NET está instalado

1. Pressione `Windows + R` no seu teclado
2. Digite `cmd` e pressione Enter
3. Na janela preta que abrir, digite:
   ```
   dotnet --version
   ```
4. Pressione Enter

**Se aparecer um número de versão** (como 6.0.0 ou superior), pule para [Como Executar](#como-executar).

**Se aparecer uma mensagem de erro**, continue com o Passo 2.

### Passo 2: Baixar e Instalar o .NET 6.0

1. Abra seu navegador de internet
2. Acesse: https://dotnet.microsoft.com/download/dotnet/6.0
3. Procure pela seção ".NET Desktop Runtime 6.0"
4. Clique em "x64" em Windows (para sistemas 64-bit)
5. Salve o arquivo (terá um nome como `windowsdesktop-runtime-6.0.xx-win-x64.exe`)
6. Dê duplo clique no arquivo baixado
7. Clique em "Install" e aguarde a conclusão
8. Clique em "Close" quando terminar

### Passo 3: Verificar a Instalação

1. Feche e reabra o Prompt de Comando (Windows + R, digite `cmd`, Enter)
2. Digite `dotnet --version` e pressione Enter
3. Agora você deve ver o número da versão

## Como Executar

### Opção 1: Usando o Executável Pré-compilado (Mais Fácil)

1. Navegue até a pasta: `TwoFishCrypto\bin\Release\net6.0-windows\win-x64\`
2. Dê duplo clique em `TwoFishCrypto.exe`
3. O aplicativo será iniciado!

### Opção 2: Compilando do Código Fonte

1. **Instale o Visual Studio Community 2022** (Gratuito)
   - Baixe de: https://visualstudio.microsoft.com/pt-br/downloads/
   - Durante a instalação, marque "Desenvolvimento para desktop com .NET"
   - Aguarde a instalação (pode levar 20-30 minutos)

2. **Abra o Projeto**
   - Inicie o Visual Studio 2022
   - Clique em "Abrir um projeto ou solução"
   - Navegue até a pasta TwoFishCrypto
   - Selecione `TwoFishCrypto.csproj` e clique "Abrir"

3. **Compilar e Executar**
   - Pressione `F5` no teclado, ou
   - Clique no botão verde "Iniciar" no topo
   - O aplicativo será compilado e iniciado automaticamente

### Opção 3: Usando Linha de Comando

1. Abra o Prompt de Comando como Administrador
2. Navegue até a pasta do projeto:
   ```
   cd C:\caminho\para\TwoFishCrypto
   ```
3. Compile o projeto:
   ```
   dotnet build -c Release
   ```
4. Execute o aplicativo:
   ```
   dotnet run
   ```

## Como Usar

### Janela Principal

1. **Selecione um Arquivo**: Clique em "Procurar" e escolha um arquivo .txt
2. **Digite a Chave de Criptografia**: 
   - Use a chave padrão ou digite sua própria
   - A chave deve ter exatamente 64 caracteres hexadecimais
3. **Digite o IV (Opcional)**:
   - Use o IV padrão ou digite seu próprio
   - O IV deve ter exatamente 32 caracteres hexadecimais
4. **Escolha a Operação**:
   - Clique em "Encriptar" para criptografar o arquivo
   - Clique em "Decriptar" para descriptografar o arquivo

### Descriptografia em Lote

1. Clique no botão "Decriptar em Lote"
2. Selecione a pasta de origem contendo arquivos criptografados
3. Selecione a pasta de destino para arquivos descriptografados
4. Clique em "Iniciar Descriptografia"

### Observações Importantes

- Apenas arquivos .txt são suportados
- Guarde sua chave de criptografia com segurança - você precisará dela para descriptografar
- Arquivos criptografados são salvos com sufixo "_encrypted"
- Arquivos originais não são modificados

## Solução de Problemas

### "O aplicativo não pode ser iniciado"
- Certifique-se de que o .NET 6.0 Desktop Runtime está instalado
- Tente executar como Administrador (clique direito → Executar como administrador)

### "dotnet não é reconhecido como comando"
- O .NET não está instalado ou não está no PATH do sistema
- Reinicie o computador após instalar o .NET
- Use o executável pré-compilado como alternativa

### Erros de "Acesso negado"
- Verifique se você tem permissões de escrita na pasta
- Tente executar o aplicativo como Administrador
- Verifique se o arquivo não está sendo usado por outro programa

### Erros de compilação no Visual Studio
- Certifique-se de ter a carga de trabalho "Desenvolvimento para desktop com .NET" instalada
- Tente limpar a solução: Compilar → Limpar Solução
- Depois recompile: Compilar → Recompilar Solução

## Valores Padrão de Criptografia

- **Chave**: `620C724A2FF22C975B5A2B9C21430820227B3D2800193AAA4CF3128803AC3ABD`
- **IV**: `56B83E3F68B60F0F29357BED335E5642`

⚠️ **Aviso de Segurança**: Para uso real, sempre gere suas próprias chaves únicas!

## Suporte

Se encontrar algum problema:
1. Verifique a seção Solução de Problemas acima
2. Certifique-se de estar usando Windows 10 ou 11
3. Verifique se o .NET 6.0 está instalado corretamente
4. Tente executar como Administrador

---
Desenvolvido por Olívio Rodrigues