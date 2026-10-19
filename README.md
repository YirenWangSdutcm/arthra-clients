<p align="center">
  <img src="docs/assets/banner.svg" width="100%" alt="ARTHRA — 骨关节影像智能评估平台 / Musculoskeletal imaging and evidence review">
</p>

<p align="center">
<strong>看清骨与软骨，量化肌肉与组织，连接临床应答与随访。</strong><br>
Visualize anatomy. Quantify tissues. Connect imaging with clinical response and follow-up.
</p>

<p align="center">
<a href="https://arthra-clinical.robust-bison-1426.chatgpt.site/">🌐 在线体验 / Explore ARTHRA</a> ·
<a href="#capabilities">核心能力 / Capabilities</a> ·
<a href="#clinical">临床与科研 / Clinical & research</a> ·
<a href="#workflow">使用流程 / Workflow</a>
</p>

## ARTHRA 能做什么？ · What can ARTHRA do?

**ARTHRA 骨关节影像智能评估平台**面向临床工作者、科研课题组及医学与计算机交叉研究者，以膝关节与下肢肌群为核心，将 **影像浏览、骨软骨分割、肌肉定量、组织表征、循证解读、疗效应答评估和随访趋势分析**整合到同一平台。它既能呈现原始影像和三维解剖结构，也能把分析结果转化为带单位的指标、可追溯的解释和可导出的研究资料，帮助使用者从“观察影像”进一步走向“量化结构、比较变化、理解临床意义”。

**ARTHRA** brings knee and lower-limb imaging into a connected workflow for **image review, bone and cartilage segmentation, muscle quantification, tissue characterization, evidence interpretation, treatment-response assessment and symptom follow-up**. Users can inspect images and 3D anatomy, obtain quantitative measurements, compare observations, review supporting evidence and export structured results.

<p align="center">
<img src="docs/assets/imaging-overview.webp" width="100%" alt="ARTHRA 影像评估：MRI原片、骨软骨分割与定量结果 / MRI, segmentation and quantitative results">
<br><sub>真实公共 MRI 案例：原片、分割结果与量化指标集中呈现。<br>A real public MRI case with images, segmentation and measurements in one view.</sub>
</p>

<a name="capabilities"></a>
## 六项核心能力 · Six core capabilities

### 01 看清关节结构 · Explore joint anatomy

导入适配的三维 NIfTI 或 DICOM 影像，在矢状位、冠状位与轴位切换观察；对适用的膝关节 DESS MRI 自动分割股骨、胫骨及对应软骨，叠加展示预测边界与参考标注，并构建可旋转、缩放的三维表面。同步查看各结构体积，在有参考标注时比较分割一致性，支持从二维切片到三维解剖的连续复核。

Review compatible NIfTI or DICOM volumes in three planes. Segment femur, tibia and associated cartilage in supported knee DESS MRI, inspect overlays and reference labels, explore interactive 3D surfaces and measure structural volumes.

### 02 量化下肢肌群 · Quantify lower-limb muscles

自动识别下肢肌群，输出逐肌群的扫描覆盖内体积、最大轴向横截面积及视野边界提示。针对符合采集要求的数据，进一步计算 CT 平均衰减值或定量脂肪图的 PDFF 指标，使肌肉形态与成分信息能够以清晰的数值、单位和图表呈现。

Obtain per-muscle volume, maximum axial cross-sectional area and scan-coverage information. Compatible calibrated CT and quantitative fat-fraction maps enable additional attenuation and PDFF measurements.

<table>
<tr>
<td width="50%" valign="top">
<a href="docs/assets/anatomy-3d.webp"><img src="docs/assets/anatomy-3d.webp" width="100%" alt="可交互骨软骨三维表面 / Interactive 3D anatomy"></a><br>
<strong>从切片到三维 / From slices to 3D</strong><br>分层查看骨与软骨的空间关系。<br>Inspect spatial relationships between bone and cartilage.
</td>
<td width="50%" valign="top">
<a href="docs/assets/muscle-quantification.webp"><img src="docs/assets/muscle-quantification.webp" width="100%" alt="肌群体积及横截面积 / Muscle volume and cross-sectional area"></a><br>
<strong>从结构到指标 / From anatomy to measurements</strong><br>将肌群分割转化为可导出的定量结果。<br>Turn muscle segmentation into exportable measurements.
</td>
</tr>
</table>

### 03 捕捉组织特征与变化 · Characterize tissues and change

分析感兴趣区域的信号均值、标准差、分位数与直方图；接入 DCE 时间—信号数据，计算相对增强、达峰时间、曲线下面积等半定量特征；对同一受试者、同侧别和匹配采集方案的两次结果进行比较，呈现绝对变化与相对变化，支持组织信号观察与纵向研究。

Characterize ROI signal distributions, analyze DCE time–signal curves using semiquantitative enhancement metrics, and compare matched examinations through absolute and relative changes.

### 04 将影像结果连接临床问题 · Connect measurements to clinical questions

将影像测量与症状、功能量表及随访记录相结合，提供结构化循证解读、诊断路径核对、治疗应答判定和症状趋势分析。结果同时展示判断条件、变化幅度和来源链接，便于临床复核、病例讨论和课题汇报。

Combine measurements with symptoms, functional scores and follow-up observations. Review structured explanations, guideline-based diagnostic pathways, treatment-response criteria and symptom trajectories, with visible calculation logic and source links.

<a name="clinical"></a>

| 临床问题 / Clinical question | 平台能提供什么 / What ARTHRA provides |
|---|---|
| **当前信息支持怎样的诊断思路？**<br>Which diagnostic pathway fits the available information? | 依据 NICE 骨关节炎指南，核对年龄、活动相关疼痛、晨僵和警示表现，组织需复核的临床线索。<br>Guideline-based review of age, activity-related pain, morning stiffness and warning signs. |
| **治疗前后是否达到应答标准？**<br>Has an observed treatment response occurred? | 按 OMERACT–OARSI 标准比较疼痛、功能与总体评估，展示绝对改善、相对改善及对应应答路径。<br>Response classification with absolute and relative changes across pain, function and global assessment. |
| **症状随访呈现什么趋势？**<br>How are symptoms changing over time? | 结合临床背景整理随访重点，对符合数据要求的 NRS 记录估计短期趋势并显示预测区间。<br>Follow-up priorities and short-term NRS trajectories with prediction intervals when sufficient observations are available. |
| **结论依据在哪里？**<br>Where does the interpretation come from? | 将指标、计算规则、适用条件与指南或方法文献关联，支持直接追溯。<br>Measurements linked to rules, acquisition conditions, guidelines and methodological sources. |

<p align="center">
<img src="docs/assets/evidence-review.webp" width="100%" alt="结构化循证解读与依据追溯 / Structured interpretation and source tracing">
<br><sub>让指标、临床问题和证据来源处于同一阅读路径。<br>Measurements, clinical questions and supporting sources in a connected review.</sub>
</p>

### 05 批量处理与过程追踪 · Process batches and follow progress

本机完整服务支持每批最多 10 份文件接入，通过任务监控查看上传进度、分析阶段和完成状态；分析完成后弹出通知，并提供结果下载。临床工作者可以连续处理检查资料，科研人员可以按批次组织影像分析。

The full local service accepts up to ten files per batch, displays upload and analysis progress, notifies users when processing finishes and provides downloadable results.

### 06 保存、调阅与导出 · Save, revisit and export

使用工作账号管理院校单位信息、历史分析记录与结果快照；通过病例编号查询检查并返回相应影像，随时调阅既往结果。导出 NIfTI 掩膜、CSV 指标表、JSON 记录、HTML 报告及 ZIP 存档，方便统计分析、研究复现和汇报整理。

Work accounts organize affiliation, analysis history and result snapshots. Search examinations, reopen associated images and export masks, measurement tables, structured records, reports and archives for research and review.

## 为临床、科研与交叉学科提供共同界面 · A shared interface across disciplines

| 使用者 / Audience | 可以完成的工作 / Practical tasks |
|---|---|
| **临床工作者 / Clinicians** | 对照原片与分割，理解肌肉和关节结构指标，复核诊断线索，比较疗效应答，组织随访。<br>Review anatomy and measurements, assess clinical criteria, compare response and plan follow-up. |
| **科研课题组 / Research teams** | 提取结构化指标，比较匹配检查的变化，保存分析记录，导出研究表格和图像结果。<br>Extract measurements, compare matched examinations, retain records and export research outputs. |
| **医学与计算机研究者 / Medical-computing researchers** | 观察模型输出如何转化为解剖测量与临床解释，查看处理阶段及实现代码，研究分割、量化与可视化的衔接。<br>Explore how model predictions become measurements and interpretable outputs through visible processing stages and source inspection. |

<a name="workflow"></a>
## 一条完整的工作流程 · One connected workflow

**选择案例或接入影像 → 分割与定量 → 原片/三维复核 → 临床与循证解读 → 保存和导出**

**Select or upload → Segment and quantify → Review images and 3D anatomy → Interpret with clinical evidence → Save and export**

<table>
<tr>
<td width="50%" valign="top">
<img src="docs/assets/guided-intake.jpg" width="100%" alt="批量接入影像分步引导 / Guided image intake"><br>
<strong>上手直观 / Guided interaction</strong><br>分步引导、动态流程示意与公共案例选择。<br>Step-by-step guides, workflow animations and public cases.
</td>
<td width="50%" valign="top">
<img src="docs/assets/clinical-response.webp" width="100%" alt="采用模拟评分的疗效应答计算 / Response calculator with synthetic scores"><br>
<strong>应答清晰 / Transparent response assessment</strong><br>展示治疗前后评分变化与判定条件。图中评分为模拟示例，不代表公共影像病例的真实疗效。<br>Score changes and explicit criteria. Ratings are synthetic, not observed outcomes of the MRI case.
</td>
</tr>
</table>

## 适配不同设备与使用习惯 · Designed for different screens and preferences

**电脑与手机响应式布局 · 深色 / 莫兰迪浅色 / 跟随系统 · 四档字体大小 · 八种界面语言**

Responsive desktop and mobile layouts, dark and Morandi light themes, system appearance and four font sizes.

简体中文 · 繁體中文 · English · 日本語 · 한국어 · Español · Français · Deutsch

<p align="center">
<img src="docs/assets/light-english.webp" width="100%" alt="英文浅色界面 / English interface in a light theme">
<br><sub>英文与莫兰迪浅色界面；评分为模拟演示，部分动态结果与来源保留原语言。<br>English interface with a Morandi light theme; ratings are synthetic and some dynamic/source text retains its original language.</sub>
</p>

## 体验与资料 · Explore and learn more

**[在线体验 ARTHRA / Open the public showcase](https://arthra-clinical.robust-bison-1426.chatgpt.site/)**：浏览公共影像案例、三维结果、预计算指标及临床计算工具。新影像上传推理、工作账号和私有存档由独立的本机完整服务提供；本仓库包含客户端工程与展示资料，分析后端及模型独立部署。

Explore public images, 3D results, precomputed measurements and clinical calculators online. New-image inference, work accounts and private archives run in the separate full local service. This repository hosts client code and project materials; the analysis backend and models are deployed separately.

**依据与来源 / Sources**：[OAIZIB-CM 公共影像](https://zenodo.org/records/14934086) · [MuscleMap](https://musclemap.github.io/MuscleMap/muscle-quantification/) · [NICE NG226](https://www.nice.org.uk/guidance/NG226/chapter/recommendations) · [OMERACT–OARSI](https://pubmed.ncbi.nlm.nih.gov/15094138/)

**深入了解 / Further reading**：[方法、验证与部署范围 / Methods and scope](docs/METHODS_AND_SCOPE.md) · [界面图像来源 / Screenshot sources](docs/SCREENSHOTS.md) · [客户端构建 / Client build](docs/CLIENT_BUILD.md)

平台用于研究与专业复核；症状趋势估计不等同于疾病进展概率，临床诊断与治疗决策由医务人员结合完整资料作出。数据、模型与代码的许可详见[项目资料](docs/METHODS_AND_SCOPE.md)。

ARTHRA supports research and professional review. Symptom trends are not disease-progression probabilities; clinical decisions incorporate the complete patient context. Licensing details are documented separately.

**联系 / Contact**：[2022123513@sdutcm.edu.cn](mailto:2022123513@sdutcm.edu.cn) · [项目交流 / Project discussions and issues](https://github.com/YirenWangSdutcm/arthra-clients/issues)
