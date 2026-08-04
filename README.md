# Build an AI-Powered Content Creation App in Blazor Using Structured Prompting

This repository contains a sample that uses [Syncfusion Blazor AI AssistView](https://www.syncfusion.com/blazor-components/blazor-ai-assistview?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026) as the conversational interface and integrates with the Gemini API for AI-powered content generation. It demonstrates how structured and mode-aware prompting can produce more consistent, purpose-specific Blog and Knowledge Base content.

## Key Sample Configurations

- Mode-specific system instructions and prompt suggestions
- Structured prompts with shared rules and output templates
- Gemini integration for AI content generation using the AI Assistview
- Features such as file attachments, Speech-to-Text and Text-to-Speech
- Response actions like Copy, Like, and Dislike.

## How the sample works

1. Syncfusion Blazor AI AssistView collects the user’s request.
2. The selected mode (Blog vs KB) provides its instructions, prompt suggestions, and output template.
3. The sample builds the structured prompt using shared rules, the mode-specific output template, the user’s request, and optional attachment content.
4. The configured AI model generates the response, which is displayed in Syncfusion Blazor AI AssistView.

The sample uses the `Gemini 3.5 Flash model`, but the workflow can be adapted to models from other AI providers.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0), or the SDK targeted by the project
- A Blazor Web App
- A Gemini API key
- Syncfusion Blazor InteractiveChat package installed to render AI AssistView.

### Install the required packages

Add the following NuGet packages to the Blazor project, these packages provide the following functionality:

- `Google.GenAI` connects the application to the Gemini API.
- `Syncfusion.Blazor.InteractiveChat` provides Syncfusion Blazor AI AssistView.
- `Syncfusion.Blazor.Themes` provides the required component styles.

> Replace * with the latest compatible package versions.

## Configure Gemini AI

This application uses the `Google.GenAI` package to send structured content requests to the Gemini API and display generated responses in Syncfusion Blazor AI AssistView.

### Get a Gemini API key

1. Sign in to [Google AI Studio](https://aistudio.google.com/app/api-keys) with a Google account.
2. Go to **Get API Key** and click **Create API Key**.
3. Choose an existing Google Cloud project or create a new one.
4. Copy the generated API key and store it securely.

## Configure credentials with environment variables

This sample uses environment variables to provide the Gemini API key and Syncfusion license key. This helps prevent sensitive credentials from being stored in project files or committed to source control.

> Ensure that the environment variable names match those expected by `Program.cs`.

### Windows PowerShell

```powershell
$env:GEMINI_API_KEY="<your-gemini-api-key>"
$env:SYNCFUSION_LICENSE_KEY="<your-syncfusion-license-key>"
```

### Windows Command Prompt

```cmd
set GEMINI_API_KEY=<your-gemini-api-key>
set SYNCFUSION_LICENSE_KEY=<your-syncfusion-license-key>
```

### macOS or Linux

```bash
export GEMINI_API_KEY="<your-gemini-api-key>"
export SYNCFUSION_LICENSE_KEY="<your-syncfusion-license-key>"
```

These commands set the environment variables for the current terminal session. When opening a new terminal, configure the variables again unless they have been added through the operating system or another secure secret-management solution.

## How to run the application

1. Clone the repository:

   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

2. Configure the Gemini API key and Syncfusion license key as environment variables.

3. Restore the project dependencies:

   ```bash
   dotnet restore
   ```

4. Build the application:

   ```bash
   dotnet build
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Open the local URL displayed in the terminal.

## Resources

- [Syncfusion Blazor AI AssistView product page](https://www.syncfusion.com/blazor-components/blazor-ai-assistview?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026)
- [Getting started with Blazor AI AssistView](https://blazor.syncfusion.com/documentation/ai-assistview/getting-started-webapp?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026)
- [Gemini integration with Blazor AI AssistView](https://blazor.syncfusion.com/documentation/ai-assistview/ai-integrations/gemini-integration?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026)

## Support and feedback

For any other queries, reach our [Syncfusion® support team](https://support.syncfusion.com/?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026) or post your queries through the [Syncfusion® community forums](https://www.syncfusion.com/forums?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026).

Request new feature through [Syncfusion® feedback portal](https://www.syncfusion.com/feedback?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026).

## License

This is a commercial product and requires a paid license for possession or use. Syncfusion's licensed software, including this component, is subject to the terms and conditions of [Syncfusion's EULA](https://www.syncfusion.com/license/studio/22.2.5/syncfusion_essential_studio_eula.pdf?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026).

You can purchase a license [here](https://www.syncfusion.com/sales/pricing?category=ui-components?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026) or start a free 30-day trial [here](https://www.syncfusion.com/downloads?utm_source=github_&utm_medium=webinar&utm_campaign=webinar_es_blazorassistview_aug2026).