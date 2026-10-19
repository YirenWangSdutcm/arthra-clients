# 部署、方法与项目资料 · Deployment, methods and project information

[返回项目介绍 / Back to project overview](../README.md)

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

**工程验证 / Engineering checks**：33 项本机自动检查、25 项公网接口与计算检查，以及隔离环境中的注册/登录/退出、NIfTI 上传推理、结果存档和跨账号访问测试。它们验证软件行为与计算一致性，不能替代临床验证。详见[验证摘要](validation-summary.json)。

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

当前交付重点为网站与本机完整版，原生客户端工程保留用于后续集成。构建通过不等于完成真机验收或正式签名。详见 [CLIENT_BUILD.md](CLIENT_BUILD.md) 和[历史成功构建](https://github.com/YirenWangSdutcm/arthra-clients/actions/runs/39208979015)。

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
