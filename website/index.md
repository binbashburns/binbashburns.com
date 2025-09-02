---
layout: default
title: Resume
permalink: /
---

<link rel="stylesheet" href="{{ '/assets/css/profile.css' | relative_url }}">

{% capture header_md %}
# Matthew Burns

_DevSecOps Engineer • Cloud-native & Kubernetes • Secure software delivery_

- **Email:** [pro.mattburns@gmail.com](mailto:pro.mattburns@gmail.com)  
- **GitHub:** [github.com/binbashburns](https://github.com/binbashburns)  
- **Certifications:** See the **[Certifications](/badges/)** page
{% endcapture %}

<div class="hero">
  <div class="hero-text">{{ header_md | markdownify }}</div>
  <img class="avatar" src="{{ '/assets/img/profile.png' | relative_url }}" alt="Matthew Burns" loading="lazy" />
</div>

---

## About me

Hi, I’m Matt: a DevSecOps Engineer focused on secure software delivery and cloud-native platforms.  
I specialize in **Kubernetes**, **containerization**, and **platform engineering** across **AWS**, **Azure**, and **GCP**. I’m big on **Infrastructure as Code**, **GitOps**, and automation with tools like **Terraform**, **Helm**, and **GitHub Actions**, grounded in a strong **Linux** foundation.

I’m also deeply interested in **OT/ICS security**. In my home lab I tinker with **PLC programming** and **Modbus/TCP** traffic, and I study ICS defense patterns informed by **SANS ICS 130** and **ICS 515**. Lately I’ve been exploring how cloud-native practices (like policy-as-code, GitOps, and telemetry) translate to industrial environments while respecting safety and reliability constraints.

Recent work includes architecting and shipping cloud-native solutions on regulated networks, building declarative delivery pipelines, and hardening multi-cluster environments. I enjoy bridging the gap between modern platform engineering and the unique realities of OT; especially where visibility, segmentation, and secure delivery meet.

---

## Experience

### Penchecks Trust - DevSecOps Engineer
_Aug 2025 – Present_ • [penchecks.com](https://penchecks.com/)
- Managed and automated AWS infrastructure and services using IaC (Terraform/CloudFormation), improving provisioning consistency and repeatability.
- Administered Microsoft Entra ID: user/group/app lifecycle, role assignments, and access controls to support secure developer workflows.
- Built and maintained CI/CD pipelines to automate secure, auditable deployments and compliance checks.
- Collaborated closely with developers and security teams to integrate security controls early and streamline vulnerability remediation.

### Army National Guard (KY) - Cyber Warfare Technician (170A), Warrant Officer  
_Jun 2020 – Present_ • [nationalguard.com](https://nationalguard.com/)
- SME and advisor on the employment of offensive/defensive cyber capabilities.
- Direct, plan, and assess cyberspace technical operations and readiness.
- Provide guidance across Army/Joint and interagency cyberspace efforts.

### Defense Unicorns - DevSecOps Engineer  
_Aug 2024 – August 2025_ • [defenseunicorns.com](https://defenseunicorns.com/)
- Delivered GitOps-managed, cloud-native infrastructure via UDS platform.
- Templated **Helm** charts for consistent K8s app deployments and policy.
- Built **GitHub Actions** CI/CD for automated, secure delivery.
- Engineered **Kubernetes** network policies; leveraged **Istio** service mesh.
- Collected/ analyzed telemetry with **Prometheus** to drive performance work.
- Published integrations for the Airgap App Store; supported multi-cluster ops (k3d, Docker).
- Partnered with stakeholders to turn complex requirements into declarative, secure solutions.

### Coalfire - Cloud Engineer II  
_Jul 2023 – Aug 2024_ • [coalfire.com](https://coalfire.com/)
- Transitioned FedRAMP/DoD environments to **NIST 800-53 rev.5**.
- Architected IaC-driven cloud environments (AWS, Azure, GCP) with automation.
- Authored reference architectures and executive-ready deliverables.
- Produced network diagrams and documentation aligned to best practices.
- Supported A&A phases and security program improvements.

### DHS CISA - IT Cybersecurity Specialist  
_Oct 2022 – Jul 2023_ • [cisa.gov](https://www.cisa.gov/)
- Contributed to solution definition, non-functional requirements, and architectural runway.
- Supported Continuous Exploration / Delivery pipeline activities.
- Participated in PI planning, demos, and Inspect & Adapt events.
- Provided oversight to foster built-in quality and technical agility.

### Coalfire - Cloud Engineer I  
_Feb 2022 – Oct 2022_ • [coalfire.com](https://coalfire.com/)
- Designed and deployed secure architectures in AWS/Azure/GCP with **IaC**.
- Implemented compliant servers, networks, and boundary protection.
- Drove testing and data reviews for effectiveness of security controls.
- Supported assessment & authorization processes and security documentation.

### Bechtel Corporation - Cybersecurity System Administrator  
_Nov 2021 – Feb 2022_ • [bechtel.com](https://bechtel.com/)
- Supported the BGCAPP Cybersecurity Program (ATO sustainment, continuous monitoring).
- Tracked processes, tested safeguards, and participated in incident response.

### Senture, LLC - Security Analyst  
_Nov 2019 – Oct 2021_ • [senture.com](https://senture.com/)
- Ran compliance & risk posture assessments (FISMA, NIST SP 800-53, SOC 2, PCI DSS).
- Built SIEM dashboards/automation; performed risk assessments and OA/ATO support.
- Managed vuln scans (Nessus); authored SOPs; coordinated across IT and vendors.

---

## Education

### University of the Cumberlands - B.A.S. Information Technology (Cybersecurity)  
_Apr 2022 – May 2023_
- **GPA:** 4.0 • **Honors:** Summa Cum Laude • President, UC Cyber Club  
- **Designation:** NSA/DHS **CAE-CD** program  
- **Selected coursework:** Application Software, Programming, Networking, Server Admin, Web Design, Business Intelligence, Policy & Compliance (SOX/GLBA/HIPAA), DR/BCP, Secure Configurations

### Somerset Community College - A.A.S. Information Security  
_2017 – 2019_
- **GPA:** 3.88 • Phi Theta Kappa  
- **Selected coursework:** Hardware/Software, AD Services, Network Security & Perimeter Defense, Linux/UNIX Admin, Python/Programming, Database Design

---

## Volunteer & Community

### Pet Cancer Foundation - **Governance, Risk & Compliance (Volunteer)**  
_June 2025 – Present_  
- Established a lightweight **GRC framework** mapped to **NIST CSF** / **CIS Controls**
- Authored foundational **security policies** (access control, data classification, vendor risk, incident response, acceptable use).  
- Performed **vendor due-diligence** for enterprise platforms; implemented data-minimization and retention standards.

---

## Projects

### SoldierSave.com - Resources for military veterans
- Antora-based static site hosted on GitLab Pages with CI/CD.
- Ongoing content curation; community suggestions welcome.
- [Link](https://soldiersave.com/)
  _Email:_ soldiersave.suggestions@gmail.com

---

_Interested in collaborating on cloud-native or DevSecOps work? I’m always happy to connect._
