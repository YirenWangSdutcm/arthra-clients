<p align="center">
  <img src="docs/assets/banner.svg" width="100%" alt="ARTHRA — 骨关节影像、组织量化与循证评估 / Musculoskeletal imaging and evidence review">
</p>

<p align="center">
  <strong>从影像结构到定量指标，从临床问题到可追溯依据。</strong><br>
  From anatomical images to quantitative measurements, and from clinical questions to traceable evidence.
</p>

<p align="center">
  <a href="https://arthra-clinical.robust-bison-1426.chatgpt.site/">🌐 在线展示 / Public demo</a> ·
  <a href="#features">功能地图 / Features</a> ·
  <a href="#gallery">界面图集 / Gallery</a> ·
  <a href="#evidence">方法与验证 / Methods</a> ·
  <a href="docs/CLIENT_BUILD.md">客户端构建 / Build</a>
</p>

<p align="center"><strong>医学影像 Medical imaging</strong>　×　<strong>临床科研 Clinical research</strong>　×　<strong>计算医学 Computational medicine</strong></p>

## 项目介绍 · Project overview

**ARTHRA 骨关节影像智能评估平台**围绕膝关节与下肢肌群，将影像接入、解剖分割、组织表征、指标量化、临床应答评估和证据追溯组织在同一工作流程中。使用者可以查看原片、复核结构边界、理解测量条件，再将结果带入课题讨论和随访评估。

**ARTHRA** is a musculoskeletal imaging and research platform focused on the knee and lower-limb musculature. It connects image intake, anatomical segmentation, tissue characterization, quantitative measurements, clinical response assessment and evidence traceability. Images, measurements and clinical context remain visible together, supporting review and reproducible research workflows.

**仓库定位 / Repository scope**：本仓库保存 Windows、Android、macOS 和 iOS 的客户端工程，以及项目介绍和界面资料。完整 Python 分析后端、模型权重、原始影像与用户数据库由独立部署管理，**不包含在本仓库中**。克隆本库不会自动获得完整分析服务。

This repository contains connected-client source code and project documentation. The full Python backend, model weights, imaging datasets and user databases are managed separately.

## 面向不同专业的使用价值 · Who it is for

| 面向人群 / Audience | 关注内容 / Focus | 使用价值 / Practical use |
|---|---|---|
| **临床工作者**<br>Clinicians | 原始影像、组织边界、扫描覆盖、症状与功能<br>Images, boundaries, coverage, symptoms and function | 结合结构测量与临床线索，复核诊断依据、疗效应答和随访计划<br>Review measurements alongside diagnostic criteria, response assessments and follow-up plans |
| **科研人员与课题组**<br>Researchers and study teams | 指标定义、采集条件、结果快照、重复性<br>Measurement definitions, acquisition and reproducibility | 导出结构化指标，用于研究性统计和协议匹配的纵向比较<br>Export measurements for study analyses and matched longitudinal comparisons |
| **医学—计算机交叉研究者**<br>Interdisciplinary researchers | 模型接口、任务状态、计算实现、指标验证<br>Model interfaces, task state, computation and validation | 理解从分割网络到临床可读输出的实现路径，设计可复现的改进实验<br>Inspect the path from segmentation to interpretable outputs and design reproducible improvements |

<a name="gallery"></a>
## 界面图集 · Interface gallery

<p align="center">
  <img src="docs/assets/imaging-overview.webp" width="100%" alt="影像评估：MRI原片、骨软骨分割、图层控制及测量结果 / MRI review and segmentation">
  <br><sub><strong>影像量化评估与依据 / Imaging assessment and supporting evidence</strong><br>OAIZIB-CM 公开 MRI 参考案例 · 原片与模型结果并列复核 / Public MRI with side-by-side segmentation review.</sub>
</p>

<table>
<tr>
<td width="50%" valign="top">
<a href="docs/assets/anatomy-3d.webp"><img src="docs/assets/anatomy-3d.webp" width="100%" alt="骨与软骨三维表面 / 3D bone and cartilage"></a><br>
<strong>三维解剖 / 3D anatomy</strong><br>旋转、缩放与图层选择，辅助空间关系复核。<br>Rotate, zoom and inspect selected anatomical surfaces.
</td>
<td width="50%" valign="top">
<a href="docs/assets/muscle-quantification.webp"><img src="docs/assets/muscle-quantification.webp" width="100%" alt="肌群体积与横截面积 / Muscle volume and CSA"></a><br>
<strong>肌肉定量 / Muscle phenotyping</strong><br>逐肌群体积、CSA 与扫描覆盖提示。<br>Per-muscle measurements with units and field-of-view context.
</td>
</tr>
<tr>
<td width="50%" valign="top">
<a href="docs/assets/evidence-review.webp"><img src="docs/assets/evidence-review.webp" width="100%" alt="结构化循证解读及来源 / Structured evidence review"></a><br>
<strong>循证解读 / Evidence review</strong><br>测量、复核建议与文献链接同步呈现。<br>Measurements, review guidance and cited sources in one view.
</td>
<td width="50%" valign="top">
<a href="docs/assets/light-english.webp"><img src="docs/assets/light-english.webp" width="100%" alt="英文浅色界面，评分为模拟示例 / English light theme with synthetic scores"></a><br>
<strong>浅色与多语言 / Light theme and languages</strong><br>莫兰迪配色与英文界面；评分为模拟输入。<br>Morandi colors and English interface; scores are synthetic.
</td>
</tr>
</table>

<details>
<summary><strong>展开操作引导与疗效应答案例 / Open the guided workflow and response example</strong></summary>

![批量影像接入引导 / Guided image intake](docs/assets/guided-intake.jpg)

使用真实公共影像缩略图和流程动画说明接入、空间核验与排队分析。阶段动画属于操作示意，不代表后台已经完成推理。

The guide explains intake, spatial validation and queued analysis. Its animation illustrates the workflow; it is not a simulated inference result.

![治疗前后应答判定 / Treatment-response assessment](docs/assets/clinical-response.webp)

**模拟数据说明 / Synthetic-data note**：疼痛 60→30、功能负担 55→40、总体评估 65→45 是用于演示公式的模拟评分，**不属于 OAIZIB-CM 病例的真实随访数据**，也不是本项目观察到的治疗效果。

These ratings demonstrate the calculator. They are not clinical follow-up labels for the displayed MRI case and do not represent observed treatment outcomes.

</details>

截图来自公共案例模式；禁用按钮体现该部署的实际能力范围。MRI 与骨软骨参考标注来自 OAIZIB-CM，骨软骨预测来自 KneeLite，肌群预测来自 MuscleMap。详见[图像来源说明](docs/SCREENSHOTS.md)。

Screenshots use public cases, not private work-account records. Reference segmentations and model predictions are distinguished; matched manual muscle references are not available for these cases.

<a name="features"></a>
## 七大模块 · Seven connected modules

| 模块 / Module | 主要功能 / Main capabilities | 输出与用途 / Outputs and use |
|---|---|---|
| **01 影像评估**<br>Imaging assessment | NIfTI / DICOM 接入；三平面浏览；骨软骨分割；参考叠加；三维表面；图层、亮度和透明度控制<br>Image intake, multiplanar review, overlays and 3D inspection | 结构体积、掩膜、参考一致性与报告<br>Volumes, masks, reference agreement and reports |
| **02 肌肉定量**<br>Muscle quantification | 下肢肌群识别；覆盖内体积；最大轴向 ROI 面积；视野边界提示；符合条件时计算 HU / PDFF<br>Muscle labels, volume, CSA and conditional composition metrics | 带单位和采集条件的逐肌群测量表<br>Per-muscle tables with units and acquisition context |
| **03 组织表征**<br>Tissue characterization | ROI 信号分布；DCE 半定量曲线；匹配协议下的两次测量比较<br>ROI histograms, DCE curves and matched comparisons | 均值、SD、分位数、相对增强、TTP、AUC 与变化量<br>Signal statistics, enhancement, TTP, AUC and changes |
| **04 循证解读**<br>Evidence interpretation | 综合解读、诊断支持、疗效应答、预后与随访、方法与来源<br>Interpretation, diagnostic support, response, follow-up and methods | 来源关联的解读卡片、规则判定与随访曲线<br>Source-linked explanations, explicit rules and trajectories |
| **05 病历档案**<br>Case archive | 检查编号检索、来源与空间信息查看、返回对应影像<br>Search examinations and reopen related images | 将检查与量化结果保持关联<br>Keep examinations connected to quantitative context |
| **06 任务监控**<br>Task monitoring | 上传进度、分析阶段、批次状态、完成通知、结果与存档下载<br>Upload progress, computation stages, batches and results | 跟踪真实处理状态，定位失败环节<br>Follow actual processing and locate failures |
| **07 用户中心**<br>Work-account center | 邮箱账号、院校单位、历史结果、主题、字号、八语言与源码查看<br>Accounts, affiliation, history, appearance and source explorer | 管理工作资料及分析记录，理解实现方法<br>Manage work records and inspect implementation |

**界面体验 / Interface experience**：深色墨蓝与莫兰迪浅色主题；四档字号；电脑与手机响应式布局；五个临床模块的可跳过分步引导。界面语言覆盖简体中文、繁体中文、英语、日语、韩语、西班牙语、法语和德语。病例数据、来源原文及部分动态结果保留原语言，不自动改写成未经核对的译文。

Dark and Morandi light themes, four font sizes, responsive layouts and skippable guides support varied users and displays. Eight interface languages are available; case data, source wording and some dynamic results retain their original language.

## 从接入到复核 · From intake to review

| 步骤 / Step | 操作 / Action | 核对内容 / Review focus |
|---|---|---|
| **1 接入 / Intake** | 选择案例或导入影像；本机每批最多 10 份文件<br>Select a case or submit up to 10 files per batch locally | 模态、序列、侧别、空间单位、扫描范围<br>Modality, sequence, side, spatial units and coverage |
| **2 计算 / Compute** | 选择适配的分析路径，查看任务进度<br>Select a compatible pipeline and monitor progress | 输入适用性、处理状态与错误信息<br>Compatibility, completion and errors |
| **3 复核 / Inspect** | 对照原片、分割、三维与定量表<br>Compare images, masks, surfaces and measurements | 边界、视野截断、单位、参考标注<br>Boundaries, truncation, units and references |
| **4 解读 / Interpret** | 补充临床线索、量表或随访记录<br>Add clinical context, scores or follow-up observations | 证据适用范围、缺失信息、判定条件<br>Evidence applicability, missing data and rule conditions |
| **5 输出 / Export** | 导出结果；本机按工作账号保存快照<br>Export results and retain account-scoped snapshots locally | 输入、方法、结果与复核状态可追溯<br>Traceability of inputs, methods, results and review status |

**输入 / Inputs**：三维 NIfTI（`.nii` / `.nii.gz`）、单序列 DICOM ZIP 与受支持的三维 DICOM；PNG/JPEG 保存为二维附件。PDFF 使用同检查、已配准且网格一致的定量图；DCE 接收已配准 ROI 的时间—信号序列。

**输出 / Outputs**：NIfTI 掩膜、CSV 指标表、JSON 追溯记录、HTML 评估报告及本机 ZIP 存档。每批 10 份是接入上限，不表示同时运行 10 个推理任务。

<a name="clinical"></a>
## 临床与科研解读 · Clinical and research interpretation

### 诊断支持 · Diagnostic support

依据 [NICE NG226](https://www.nice.org.uk/guidance/NG226/chapter/recommendations) 核对年龄、活动相关疼痛、晨僵及急性警示表现，组织诊断路径与复核重点。缺失选项保持未知，不自动视为阴性。

The diagnostic-support view organizes clinical features and warning signs against a guideline-based pathway. It supports clinician review rather than producing an image-only diagnosis or individual disease probability.

### 疗效应答 · Treatment response

按 [OMERACT–OARSI 标准](https://pubmed.ncbi.nlm.nih.gov/15094138/) 比较疼痛、功能负担与患者总体评估，统一使用“0–100 分、越高越差”的方向。输出基线、随访、绝对改善、相对改善及达到的判定路径。

The calculator exposes observed changes and the response pathway across three consistently oriented scales. An observed response alone does not establish treatment causality.

### 预后与随访 · Prognosis and follow-up

结合临床背景整理随访重点；对满足要求的 NRS 疼痛记录做线性趋势分析，并输出单次未来评分的预测区间。当前要求至少 5 次记录、观察跨度至少 28 天，预测窗口不超过观察跨度的一半且最长 90 天。[统计方法](https://itl.nist.gov/div898/handbook/pmd/section5/pmd512.htm)

The follow-up view separates contextual prognostic factors from a statistical symptom trajectory. Extrapolation concerns NRS scores, not cartilage progression, surgery, recurrence or survival probabilities.

### 采集条件与指标边界 · Acquisition-aware biomarkers

- **体积与 CSA / Volume and CSA**：按掩膜和物理空间计算，受扫描覆盖影响；当前 CSA 是最大 RAS 轴向 ROI 面积。
- **HU / CT attenuation**：需确认 CT 强度校准，普通 MRI 信号不作为 HU。
- **PDFF / Fat fraction**：需符合要求的定量图，不将普通 MRI 亮度换算为脂肪百分比。
- **DCE / Dynamic enhancement**：输出半定量相对增强、TTP 和 AUC；真实血流量和药代动力学参数需要额外采集与模型条件。
- **T2 mapping**：展示采集条件及方法参考，当前不从常规 MRI 自动推算水 T2。

Measurements remain tied to their acquisition and calculation method. See [MuscleMap](https://musclemap.github.io/MuscleMap/muscle-quantification/) and [RSNA QIBA DCE-MRI resources](https://qibawiki.rsna.org/index.php/DCE_MRI_Biomarker_Ctte).

<a name="access"></a>
## 两种部署范围 · Two deployment modes

| 能力 / Capability | 本机完整版 / Local full service | 公网展示版 / Public showcase |
|---|---|---|
| 影像、分割、三维与公共案例 / Imaging and public cases | 支持 / Available | 支持 / Available |
| 新影像上传与模型推理 / New-image inference | 按模型适用条件支持 / Available for compatible inputs | 未接通 / Not connected |
| 邮箱登录与院校资料 / Login and affiliation | 本机工作账号 / Local work accounts | 未接通云端账号 / No cloud account service |
| 历史结果与存档 / History and archives | 保存在本机 / Stored locally | 公共结果浏览与下载 / Public-result access |
| 临床规则与趋势计算 / Clinical calculators | 计算并保存 / Calculate and save | 可计算，不写入私有云档案 / Stateless calculations |
| 数据位置 / Data location | 本机服务目录 / Local deployment | 已发布公共案例资源 / Published public-case assets |

- **公网 / Public**：[ARTHRA 在线展示](https://arthra-clinical.robust-bison-1426.chatgpt.site/)。地区与网络可达性可能不同，发布成功不代表完成所有网络的访问验收。
- **本机 / Local**：`http://127.0.0.1:8877/`，仅适用于已经部署并启动完整服务的电脑。`127.0.0.1` 指向访问者自己的设备，不是可分享的远程地址。
- **账号与存储 / Accounts and storage**：两种部署不自动同步。本机采用加盐密码哈希、HttpOnly 会话和账号隔离的结果目录；私人数据不随本仓库发布。

The public showcase and local full service are separate deployments. Public access does not expose the original local database or make local accounts automatically available on another device.

<a name="evidence"></a>
## 方法、数据与验证 · Methods, data and validation

### 分析引擎 · Analysis engines

| 引擎 / Engine | 角色 / Role | 当前范围 / Scope |
|---|---|---|
| **KneeLite 2.5D U-Net** | 骨软骨分割 / Bone and cartilage segmentation | 274,914 参数；右膝 DESS MRI；5 类结构 / 274,914 parameters, right-knee DESS MRI, five structures |
| **MuscleMap 1.4 + MONAI** | 下肢肌群分割 / Lower-limb muscle segmentation | 轴向滑窗与原始网格定量 / Axial sliding-window inference and native-grid measurements |
| **临床规则与统计模块**<br>Clinical rules and statistics | 诊断路径、应答阈值、NRS 趋势和 DCE 曲线<br>Diagnostic pathways, response criteria and trajectories | 显式规则与公式，保留依据 / Explicit rules and formulas with source context |

### 本地研究验证 · Local research evaluation

KneeLite 使用 **32 例训练、8 例验证、10 例独立测试**，训练 24 轮。测试集五类结构宏平均 Dice 为 **0.8999**，按病例 bootstrap 的 95% 区间为 **0.8912–0.9093**；评估在 192×192 工作网格进行。

The five-structure test-set macro Dice is **0.8999** on the working grid. These results describe segmentation overlap in a small research split, not diagnostic accuracy, clinical utility or generalization to other protocols.

| 结构 / Structure | 测试平均 Dice / Mean test Dice |
|---|---:|
| 股骨 / Femur | 0.9683 |
| 股骨软骨 / Femoral cartilage | 0.8565 |
| 胫骨 / Tibia | 0.9763 |
| 胫骨内侧软骨 / Medial tibial cartilage | 0.8446 |
| 胫骨外侧软骨 / Lateral tibial cartilage | 0.8536 |

**工程验证 / Engineering checks**：33 项本机自动检查、25 项公网接口与计算检查，以及隔离环境中的注册/登录/退出、NIfTI 上传推理、结果存档和跨账号访问测试。它们验证软件行为与计算一致性，不能替代临床验证。详见[验证摘要](docs/validation-summary.json)。

### 数据与来源 · Data and sources

1. **OAIZIB-CM / CartiMorph** — [数据发布](https://zenodo.org/records/14934086) · [方法论文](https://doi.org/10.1016/j.media.2023.103035)。演示使用 `oaizib_453`、`oaizib_456`、`oaizib_484`，保留数据许可及原作者署名。
2. **MuscleMap** — [量化文档](https://musclemap.github.io/MuscleMap/muscle-quantification/)。肌群结果为模型预测；本地没有匹配人工肌肉标注用于准确率验证。
3. **NICE NG226** — [骨关节炎诊断与管理](https://www.nice.org.uk/guidance/NG226/chapter/recommendations)。
4. **OMERACT–OARSI** — [原始应答标准研究](https://pubmed.ncbi.nlm.nih.gov/15094138/)。
5. **RSNA QIBA / NIST** — [DCE-MRI 技术规范](https://qibawiki.rsna.org/index.php/DCE_MRI_Biomarker_Ctte) · [单次未来观测的预测区间](https://itl.nist.gov/div898/handbook/pmd/section5/pmd512.htm)。

<a name="engineering"></a>
## 工程实现 · Engineering view

```text
影像 / Images + 临床输入 / Clinical inputs
                    │
                    ▼
浏览器界面 / Browser UI ── 工作账号与任务监控 / Accounts & task state
                    │
                    ▼
独立部署的分析服务 / Separately deployed analysis service
  ├─ NIfTI / DICOM 解析、几何与适用条件核验
  │  Image parsing, geometry and compatibility checks
  ├─ PyTorch / MONAI 分割与原始网格量化
  │  Segmentation and native-grid quantification
  ├─ 临床规则、信号曲线与统计随访
  │  Clinical rules, signal curves and follow-up statistics
  └─ 账号隔离的快照、报告与存档
     Account-scoped snapshots, reports and archives
                    │
                    ▼
NIfTI · CSV · JSON · HTML · ZIP

本仓库 / This repository
Windows / Android / macOS / iOS 客户端 → 已部署的网站
Connected client shells → Deployed website origin
```

完整平台采用 Python、PyTorch、MONAI、NumPy、SciPy、NiBabel、pydicom、SQLite 和 WebGL。任务事件与结果快照使“输入了什么、计算到哪一步、输出来自哪里”能够被复核。原生客户端通过 WebView 访问已部署服务，不在移动端内置上述 Python 推理组件。

The full platform combines medical-image processing, numerical computing, durable task state and WebGL. Native projects in this repository are connected clients; the processing stack is not embedded in the mobile apps.

### 仓库目录 · Repository layout

```text
arthra-clients/
├── windows/                  WinForms + WebView2 client and installer
├── android/                  Android WebView client and file picker
├── apple/                    SwiftUI + WKWebView, macOS and iOS targets
├── .github/workflows/        Android / Apple build validation
├── docs/assets/              Brand artwork and public-case screenshots
├── docs/CLIENT_BUILD.md      Build requirements and distribution status
├── docs/SCREENSHOTS.md       Image provenance and example-data notes
├── docs/validation-summary.json
└── README.md
```

### 客户端状态 · Client status

| 平台 / Platform | 实现 / Implementation | 已有验证 / Verification | 分发状态 / Distribution |
|---|---|---|---|
| Windows 10/11 x64 | .NET Framework + WebView2 | 本机编译通过 / Local build passed | 未签名内部验收包 / Unsigned internal preview |
| Android 8+ | Java + Android WebView | CI 构建通过 / CI build passed | 调试签名 APK / Debug-signed APK |
| macOS 13+ | SwiftUI + WKWebView | Universal 构建通过 / Universal build passed | 未签名、未公证 / Unsigned, not notarized |
| iOS / iPadOS 16+ | SwiftUI + WKWebView | 模拟器目标编译通过 / Simulator target built | 设备安装需 Apple 签名及分发 / Device signing required |

当前交付重点为网站与本机完整版，原生客户端工程保留用于后续集成。构建通过不等于完成真机验收或正式签名。详见 [CLIENT_BUILD.md](docs/CLIENT_BUILD.md) 和[历史成功构建](https://github.com/YirenWangSdutcm/arthra-clients/actions/runs/39208979015)。

Current delivery focuses on the website and local full service. Client projects remain available for integration; compilation does not establish device acceptance or production signing.

## 术语速览 · Quick glossary

| 术语 / Term | 含义 / Meaning |
|---|---|
| ROI | 感兴趣区域 / Region of interest |
| CSA | 横截面积 / Cross-sectional area in a specified plane |
| HU | 经校准的 CT 衰减单位 / Hounsfield units for calibrated CT |
| PDFF | 质子密度脂肪分数 / Proton-density fat fraction |
| DCE / TTP / AUC | 动态增强、达峰时间、曲线下面积 / Dynamic enhancement, time to peak, area under the curve |
| Dice | 分割与参考掩膜的空间重叠 / Segmentation–reference spatial overlap |
| NRS | 数字疼痛评分量表 / Numerical rating scale for pain |

## 合作与使用范围 · Collaboration and intended use

欢迎围绕分割质量、协议适配、量化重复性、临床结局设计、界面可用性和模型部署开展交流。反馈问题时请说明模块、复现步骤、影像模态，并使用公共或适当去标识化的示例。

We welcome collaboration on segmentation, protocol adaptation, repeatability, clinical study design, usability and deployment. Reports should identify the module and reproduction steps using public or appropriately de-identified examples.

项目面向研究展示和临床专业人员复核，不将自动测量包装为已确诊结论。当前没有宣称取得医疗器械注册、完成前瞻性临床验证或获得指南机构背书。

ARTHRA supports research demonstrations and review by clinical professionals. It does not claim medical-device approval, prospective clinical validation or endorsement by cited guideline organizations.

**许可 / Licensing**：数据、模型和代码分别遵循各自许可。OAIZIB-CM 按其 **CC BY-NC 4.0** 发布许可使用并引用 CartiMorph；MuscleMap 保留其发布许可和署名。本仓库尚未声明统一的开源代码许可证，展示内容不自动构成任意再分发授权。

**联系 / Contact**：[2022123513@sdutcm.edu.cn](mailto:2022123513@sdutcm.edu.cn) · [项目反馈 / Issues](https://github.com/YirenWangSdutcm/arthra-clients/issues)

<p align="center"><sub>文档与界面资料更新 / Documentation and interface capture: 2026-10-19<br>ARTHRA · Clinical imaging × Research × Computing</sub></p>
