# binbashburns.com

Monorepo for:
- **BadgeBox API (C#/.NET 8):** Normalize public Credly badges to a stable schema (+ validity).
- **BadgeBox CLI (C#):** Consumer that fetches from the API and writes `website/_data/credly-badges.json`.
- **Résumé site (Jekyll):** GitHub Pages résumé that renders badges in real time at build.

## Quick start (local)
```bash
# 1) API
dotnet build
dotnet run --project src/BadgeBox.Api

# 2) Fetch data into the Jekyll site
BADGEBOX_API=http://localhost:5080 USER_ID=02999b05-9f6e-4eb8-9c6b-556b7ec90f54 \
  dotnet run --project src/BadgeBox.Cli

# 3) Serve résumé site
cd website
bundle install
bundle exec jekyll serve
```
## Structure
```
binbashburns.com/
├─ README.md
├─ docker-compose.yml
├─ Directory.Build.props
├─ BadgeBox.sln
├─ src/
│  ├─ BadgeBox.Api/
│  │  ├─ Program.cs
│  │  ├─ appsettings.json
│  │  ├─ Models/
│  │  │  └─ BadgeDto.cs
│  │  └─ Services/
│  │     ├─ ICredlyClient.cs
│  │     ├─ CredlyClient.cs
│  │     └─ BadgeNormalizer.cs
│  └─ BadgeBox.Cli/
│     └─ Program.cs
├─ tests/
│  └─ BadgeBox.Tests/
│     └─ BadgeNormalizerTests.cs
├─ website/
│  ├─ _config.yml
│  ├─ Gemfile
│  ├─ index.md
│  ├─ badges.md
│  ├─ _includes/
│  │  └─ badge-grid.html
│  ├─ _data/
│  │  └─ credly-badges.json   # populated by CI / CLI
│  └─ assets/
│     └─ css/
│        └─ badges.css
└─ .github/
   └─ workflows/
      ├─ api-ci.yml
      └─ website-build.yml

```