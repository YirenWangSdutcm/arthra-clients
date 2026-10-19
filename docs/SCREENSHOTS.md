# 界面图像与来源 · Screenshots and provenance

新增截图于 2026-10-19 从隔离的公共案例预览服务采集，不读取本机工作账号、私有上传文件或历史患者记录。公共预览与本机完整版使用同一套主要界面；禁用按钮体现公共预览的实际能力范围。

New screenshots were captured from an isolated public-case preview. They do not expose local account records or private uploads. Disabled controls reflect the public preview's actual capabilities.

| 文件 / File | 内容 / Content | 数据性质 / Data |
|---|---|---|
| `banner.svg`, `brand-mark.svg` | 项目标识与工作流程 / Identity and workflow artwork | 原生 SVG；不是医学认证标识 / Code-native artwork, not a certification mark |
| `imaging-overview.webp` | 原片、分割与测量 / Imaging and measurements | OAIZIB-CM `oaizib_453` |
| `anatomy-3d.webp` | 预测三维表面 / Predicted surfaces | KneeLite working-grid output |
| `muscle-quantification.webp` | 肌群体积与 CSA / Muscle metrics | MuscleMap result, native-grid quantitative values |
| `evidence-review.webp` | 解读与来源 / Interpretation and sources | Public case; no private clinical context |
| `clinical-response.webp` | 疗效应答计算 / Response assessment | Synthetic: pain 60→30, function 55→40, global 65→45 |
| `light-english.webp` | 英文浅色界面 / English light theme | Same synthetic scores; result text retains its original language |
| `guided-intake.jpg` | V4 接入引导 / V4 intake guide | Public thumbnails and illustrative workflow animation |

MRI 与骨软骨参考标注来自 [OAIZIB-CM](https://zenodo.org/records/14934086)，关联论文为 [CartiMorph](https://doi.org/10.1016/j.media.2023.103035)。保留原作者署名及 CC BY-NC 4.0 数据许可。模型叠加结果是预测结果，当前案例没有匹配的人工肌群标注用于本地准确率验证。

MRI and bone/cartilage references originate from OAIZIB-CM. Retain attribution and the dataset's noncommercial license conditions. Model overlays are predictions, not clinical ground truth.

疗效应答中的评分仅演示公式，不是对应 MRI 病例的真实随访结局。截图没有改写测量值或添加虚假诊断。PNG 转为 WebP 仅用于降低文件体积。

Response ratings demonstrate the calculation, not a patient outcome. Captures were not altered to invent measurements or diagnoses. PNG-to-WebP encoding only reduces repository image size.
