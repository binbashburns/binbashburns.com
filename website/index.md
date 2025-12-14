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

Hi, I'm Matt: a DevSecOps Engineer specializing in **Kubernetes**, **cloud platforms** (AWS/Azure/GCP), and **secure software delivery**. I focus on **Infrastructure as Code**, **GitOps**, and automation with **Terraform**, **Helm**, and **GitHub Actions**.

I'm passionate about **penetration testing** and offensive security. I recently earned my **GIAC Certified Penetration Tester (GCPN)** and enjoy exploring vulnerabilities and attack vectors in my home lab.

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
_Aug 2024 – Aug 2025_ • [defenseunicorns.com](https://defenseunicorns.com/)
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

### CodeYou (Louisville) - **Software Engineering with C# (Student)**  
_Aug 2025 – Apr 2026_  
- Enrolled in the Software Development cohort focusing on C#, .NET, ASP.NET Core, and full-stack development.
- Building skills in object-oriented programming, web APIs, database design, and modern software architecture.

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

### CodeYou (Louisville) - **Cybersecurity Mentor (Volunteer)**  
_Aug 2025 – Present_  
- Mentor students in the **Intro to Cyber** cohort, providing guidance on foundational security concepts and career pathways.
- Lead hands-on penetration testing demos covering tools like Nmap, Metasploit, Burp Suite, and wireless attacks with WiFi Pineapple.
- Moderate discussions on real-world security scenarios, threat landscapes, and defensive strategies.
- Provide one-on-one mentorship to help students build practical skills and confidence in cybersecurity.

### Pet Cancer Foundation - **Governance, Risk & Compliance (Volunteer)**  
_Jun 2025 – Present_  
- Established a lightweight **GRC framework** mapped to **NIST CSF** / **CIS Controls**
- Authored foundational **security policies** (access control, data classification, vendor risk, incident response, acceptable use).  
- Performed **vendor due-diligence** for enterprise platforms; implemented data-minimization and retention standards.

---

## Projects

### SoldierSave

[![Live site](https://img.shields.io/badge/site-soldiersave.com-blue)](https://soldiersave.com/) [![GitHub](https://img.shields.io/badge/code-binbashburns%2Fsoldiersave.com-black)](https://github.com/binbashburns/soldiersave.com)

- Blazor WebAssembly site hosted via GitHub Pages, backed by a structured `benefits.json` dataset.
- Provides searchable, tag-filtered benefits, discounts, and resources for service members, veterans, and families.
- Community contributions flow through GitHub Issues and auto-generated pull requests, plus scheduled link checking via GitHub Actions.

### BadgeBox

[![Live site](https://img.shields.io/badge/site-badge--box.com-blue)](https://badge-box.com) [![GitHub](https://img.shields.io/badge/code-binbashburns%2Fbadgebox--resume-black)](https://github.com/binbashburns/badgebox-resume)

- Resume template that pulls live **Credly** certifications via a .NET 9 minimal API and CLI, then renders them into a Jekyll site.
- Ships with a GitHub Actions workflow that builds the API/CLI, generates normalized badge JSON, and publishes the site to GitHub Pages or a custom domain.
- Designed to be forked and customized so others can quickly stand up their own resume + badges site.

---

_Interested in collaborating on cloud-native or DevSecOps work? I’m always happy to connect._
