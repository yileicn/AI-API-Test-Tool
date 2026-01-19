# AI Test Tool

一个功能强大的 Windows 桌面工具集，包含 **AI API 稳定性测试** 和 **AI Playground** 两大核心功能。专为测试 API 接口的稳定性和一致性，以及优化 AI Prompt 而设计。

## 📸 界面预览

### 主界面
![Main UI](images/Main%20UI.png)

### AI API Stability Test
![AI API Test](images/AI%20API%20Test.png)

### AI Playground
![AI Playground](images/AI%20Playground.png)


![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-0078D6?style=flat-square&logo=windows)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

## ✨ 功能特性

### 🔌 AI API Stability Test

#### 🚀 批量请求测试
- 支持 **GET、POST、PUT、PATCH、DELETE** 等 HTTP 方法
- 可配置请求次数（1-10000次）
- 支持**顺序执行**和**并行执行**两种模式
- 可设置请求间隔延迟和超时时间

#### 🔍 响应差异分析
- 自动检测多次请求响应的差异
- 支持**完整响应对比**和**指定字段对比**两种模式
- 使用 MD5 Hash 快速识别不同响应
- 详细的 JSON 差异对比报告

#### 📊 统计报告
- 请求成功/失败统计
- 响应时间分析（平均、最小、最大、P50/P90/P95/P99）
- 状态码分布统计
- 响应一致性分析

#### 💾 请求管理
- 保存常用请求配置
- 支持导入/导出请求配置（JSON格式）
- 双击快速加载已保存的请求

### 🤖 AI Playground

#### 🎯 Prompt 测试与优化
- 支持 OpenAI GPT 系列模型（GPT-4o、GPT-4、GPT-3.5-turbo、o1 等）
- 可视化配置 System Prompt（支持 `{{变量名}}` 模板）
- 参数调节：Temperature、Max Tokens、Top P
- 实时对话测试，Token 使用统计
- Prompt 配置保存、导入、导出

#### 🔧 Function Calling / Tools
- 支持 OpenAI Function Calling 功能
- 可视化管理 Function 定义
- Functions 与 Prompt 配置绑定保存
- 手动处理 Tool Call 响应

#### 📝 变量模板
- 支持在 System Prompt 中使用 `{{变量名}}` 动态替换
- 可视化变量管理界面
- 变量与 Prompt 配置一起保存

### 🛠️ 实用工具
- 文本转 JSON 字符串工具（自动转义特殊字符）
- 响应内容格式化显示
- 双击查看完整响应详情

## 📦 安装要求

- Windows 10/11
- .NET 8.0 Runtime

## 🚀 快速开始

### 从源码构建

```bash
# 克隆仓库
git clone https://github.com/your-username/AI-API-Test-Tool.git
cd AI-API-Test-Tool

# 构建项目
dotnet build

# 运行
dotnet run
```

### 直接运行

下载 Release 中的可执行文件，双击运行 `AIAPITestTool.exe`。

## 📖 使用说明

### 🔌 AI API Stability Test

#### 基本使用

1. **输入 API URL** - 在 URL 输入框中填写要测试的 API 地址
2. **选择请求方法** - 从下拉框选择 GET、POST 等方法
3. **配置 Headers**（可选）- 以 JSON 格式输入请求头
   ```json
   {
     "Authorization": "Bearer your-token",
     "Content-Type": "application/json"
   }
   ```
4. **配置 Body**（可选）- 对于 POST/PUT/PATCH 请求，输入请求体
5. **设置测试参数**
   - 调用次数：执行请求的次数（1-10000次）
   - 超时时间：单次请求的超时秒数
   - 请求间隔：顺序执行时每次请求的间隔毫秒数
   - 并行执行：是否同时发送多个请求
6. **点击执行** - 开始测试

#### 字段对比功能

当 API 响应中包含动态字段（如时间戳、随机ID）时，可以使用字段对比功能只对比关心的字段：

1. 在"对比字段"文本框中输入要对比的字段路径，每行一个
2. 勾选"仅对比指定字段"
3. 执行测试

**字段路径格式示例：**
```
data.user.id
data.items[0].name
result.list[2].value
response.nested.deep.field
```

#### 保存和管理请求

- **保存请求** - 点击"保存"按钮，输入名称保存当前配置
- **加载请求** - 双击左侧列表中的已保存请求
- **删除请求** - 选中请求后点击"删除"按钮
- **导出/导入** - 使用导出/导入按钮备份或分享请求配置

### 🤖 AI Playground

#### 基本使用

1. 点击主界面的 **"🤖 AI Playground"** 卡片打开 AI Playground 窗口
2. 点击 **⚙️** 按钮配置 OpenAI API Key（支持环境变量）
3. 选择模型并配置参数（Temperature、Max Tokens、Top P）
4. 编写 System Prompt（系统提示词，支持 `{{变量名}}` 模板）
5. 可选：添加变量，在 System Prompt 中使用 `{{变量名}}` 引用
6. 在右侧对话区域输入消息并发送
7. 查看 AI 响应和 Token 统计

#### Function Calling / Tools

1. 在 Tools 下拉框中选择 "Function"
2. 点击"管理"按钮打开 Functions 管理窗口
3. 添加、编辑或删除 Function 定义
4. Functions 会自动与当前 Prompt 配置绑定保存
5. 当 AI 返回 Tool Call 时，可以手动输入响应继续对话

#### Prompt 管理

- **保存 Prompt** - 点击"保存"按钮，输入名称保存当前配置（包括 System Prompt、参数、变量、Functions）
- **加载 Prompt** - 双击左侧列表中的已保存 Prompt
- **删除 Prompt** - 选中 Prompt 后点击"删除"按钮
- **导出/导入** - 使用导出/导入按钮备份或分享 Prompt 配置


## 🔧 技术栈

- **框架**: .NET 8.0 Windows Forms
- **JSON处理**: Newtonsoft.Json
- **OpenAI SDK**: OpenAI NuGet Package (v2.8.0)
- **UI主题**: Catppuccin Mocha 配色方案

## 📁 项目结构

```
AI-API-Test-Tool/
├── MainForm.cs                  # 主导航页面
├── ApiTestForm.cs               # API Stability Test 窗体
├── ApiTestForm.Designer.cs      # API 测试窗体设计器代码
├── PromptTestForm.cs            # AI Playground 窗体
├── PromptTestForm.Designer.cs   # AI Playground 窗体设计器代码
├── OpenAIChatService.cs         # OpenAI 聊天服务封装
├── FunctionsToolsForm.cs        # Functions 管理窗体
├── OpenAISettingsDialog.cs     # OpenAI 设置对话框
├── SaveRequestDialog.cs         # 保存请求对话框
├── TextToJsonDialog.cs          # 文本转JSON对话框
├── Models.cs                    # 数据模型定义
├── Program.cs                   # 程序入口
├── images/                      # 界面截图
│   ├── Main UI.png
│   ├── AI API Test.png
│   └── AI Playground.png
├── AIAPITestTool.csproj         # 项目文件
└── AIAPITestTool.sln            # 解决方案文件
```

## 📝 数据存储

配置文件存储在：
```
%APPDATA%\APITestTool\
├── saved_requests.json      # 已保存的 API 请求配置
├── saved_prompts.json       # 已保存的 Prompt 配置
└── openai_settings.json     # OpenAI API 设置
```

## 🤝 贡献

欢迎提交 Issue 和 Pull Request！

## 📄 许可证

本项目采用 MIT 许可证 - 详见 [LICENSE](LICENSE) 文件。
