# React Frontend Migration Guide - LanguageSkeleton

## Projektöversikt

Denna guide beskriver hur man bygger en React-frontend som ersätter Blazor.UI-projektet för LanguageSkeleton API.

**Scope:** Endast två sidor/routes behövs:

- Home (`/`)
- Basic Sentence Builder (`/basic-sentence`)

## 1. Project Setup

### Skapa React-projektet

/Använd Vite för snabb setup med TypeScript
npm create vite@latest language-skeleton-react -- --template react-ts cd language-skeleton-react npm install/

### Installera dependencies

npm install react-router-dom axios npm install bootstrap npm install @types/bootstrap --save-dev

## 2. API Configuration

### API Base URL

Development: https://localhost:7217 CORS: AllowAnyOrigin (redan konfigurerat i API)

### API Endpoints

**Nouns:**

- `GET /api/Noun` - Hämta alla substantiv
- `GET /api/Noun/{id}` - Hämta specifikt substantiv

**Verbs:**

- `GET /api/Verb` - Hämta alla verb
- `GET /api/Verb/{id}` - Hämta specifikt verb

**Sentence:**

- `POST /api/SentenceContent` - Generera mening

## 3. TypeScript Types

### DTOs (src/types/api.ts)

// Noun Types export interface GetAllNounsQueryDto { id: string; singularForm: string; pluralForm?: string; definiteSingularForm?: string; definitePluralForm?: string; }
// Verb Types export interface GetVerbQueryDto { id: string; presentTense: string; futureTense?: string; pastTense?: string; perfectTense?: string; }
// Sentence Types export interface DisplayBasicSentenceQuery { tense: string; statementOrQuestion: string; subjectId: string; subjectDefiniteness: string; subjectGrammaticalNumber: string; predicateId: string; }
export interface DisplayBasicSentenceDto { tense: string; displaySentence: string; statementOrQuestion: string; predicateId: string; predicatePresentTense: string; predicateVerbConjugation: string; subjectId: string; subjectDefiniteness: string; subjectGrammaticalNumber: string; objectId?: string; objectGrammaticalNumber?: string; objectDefiniteness?: string; }

## 4. API Service Layer

### API Client (src/services/apiClient.ts)

import axios from 'axios';
const API_BASE_URL = 'https://localhost:7217/api';
export const apiClient = axios.create({ baseURL: API_BASE_URL, headers: { 'Content-Type': 'application/json', }, });

### Services (src/services/)

**nounService.ts:**
import { apiClient } from './apiClient'; import { GetAllNounsQueryDto } from '../types/api';
export const nounService = { async getAll(): Promise<GetAllNounsQueryDto[]> { const response = await apiClient.get<GetAllNounsQueryDto[]>('/Noun'); return response.data; },
async getById(id: string): Promise<GetAllNounsQueryDto> { const response = await apiClient.get<GetAllNounsQueryDto>(/Noun/${id}); return response.data; }, };

**verbService.ts:**
import { apiClient } from './apiClient'; import { GetVerbQueryDto } from '../types/api';
export const verbService = { async getAll(): Promise<GetVerbQueryDto[]> { const response = await apiClient.get<GetVerbQueryDto[]>('/Verb'); return response.data; },
async getById(id: string): Promise<GetVerbQueryDto> { const response = await apiClient.get<GetVerbQueryDto>(/Verb/${id}); return response.data; }, };

**sentenceService.ts:**
import { apiClient } from './apiClient'; import { DisplayBasicSentenceQuery, DisplayBasicSentenceDto } from '../types/api';
export const sentenceService = { async createSentence(query: DisplayBasicSentenceQuery): Promise<DisplayBasicSentenceDto> { const response = await apiClient.post<DisplayBasicSentenceDto>('/SentenceContent', query); return response.data; }, };

## 5. Custom Hooks

### useNouns (src/hooks/useNouns.ts)

import { useState, useEffect } from 'react'; import { nounService } from '../services/nounService'; import { GetAllNounsQueryDto } from '../types/api';
export const useNouns = () => { const [nouns, setNouns] = useState<GetAllNounsQueryDto[]>([]); const [loading, setLoading] = useState(true); const [error, setError] = useState<string | null>(null);
useEffect(() => { const fetchNouns = async () => { try { setLoading(true); const data = await nounService.getAll(); setNouns(data); setError(null); } catch (err) { setError('Failed to load nouns'); console.error(err); } finally { setLoading(false); } };
fetchNouns();
}, []);
return { nouns, loading, error }; };

### useVerbs (src/hooks/useVerbs.ts)

import { useState, useEffect } from 'react'; import { verbService } from '../services/verbService'; import { GetVerbQueryDto } from '../types/api';
export const useVerbs = () => { const [verbs, setVerbs] = useState<GetVerbQueryDto[]>([]); const [loading, setLoading] = useState(true); const [error, setError] = useState<string | null>(null);
useEffect(() => { const fetchVerbs = async () => { try { setLoading(true); const data = await verbService.getAll(); setVerbs(data); setError(null); } catch (err) { setError('Failed to load verbs'); console.error(err); } finally { setLoading(false); } };
fetchVerbs();
}, []);
return { verbs, loading, error }; };

## 6. Layout Components

### NavMenu (src/components/layout/NavMenu.tsx)

import React, { useState } from 'react'; import { Link } from 'react-router-dom';
export const NavMenu: React.FC = () => { const [collapsed, setCollapsed] = useState(true);
const toggleNavbar = () => setCollapsed(!collapsed);
return ( <> <div className="top-row ps-3 navbar navbar-dark"> <div className="container-fluid"> <a className="navbar-brand" href="/">Language Skeleton</a> <button title="Navigation menu" className="navbar-toggler" onClick={toggleNavbar} > <span className="navbar-toggler-icon"></span> </button> </div> </div>

  <div className={`${collapsed ? 'collapse' : ''} nav-scrollable`} onClick={toggleNavbar}>
    <nav className="flex-column">
      <div className="nav-item px-3">
        <Link className="nav-link" to="/">
          <span className="oi oi-home" aria-hidden="true"></span> Hem
        </Link>
      </div>
      
      <div className="nav-item px-3">
        <Link className="nav-link" to="/basic-sentence">
          <span className="oi oi-list-rich" aria-hidden="true"></span> Grundläggande mening
        </Link>
      </div>
    </nav>
  </div>
</>
); };

### MainLayout (src/components/layout/MainLayout.tsx)

import React from 'react'; import { NavMenu } from './NavMenu';
interface MainLayoutProps { children: React.ReactNode; }
export const MainLayout: React.FC<MainLayoutProps> = ({ children }) => { return ( <div className="page"> <div className="sidebar"> <NavMenu /> </div>

  <main>
    <article className="content px-4">
      {children}
    </article>
  </main>
</div>
); };

## 7. Page Components

### Home Page (src/pages/Home.tsx)

import React from 'react';
export const Home: React.FC = () => { return ( <div> <h1>Träna grammatik</h1> <p>Välkommen!</p> </div> ); };

### Basic Sentence Page (src/pages/BasicSentence.tsx)

import React, { useState } from 'react'; import { useNouns } from '../hooks/useNouns'; import { useVerbs } from '../hooks/useVerbs'; import { sentenceService } from '../services/sentenceService'; import { DisplayBasicSentenceQuery } from '../types/api';
export const BasicSentence: React.FC = () => { const { nouns, loading: nounsLoading } = useNouns(); const { verbs, loading: verbsLoading } = useVerbs();
const [formData, setFormData] = useState<DisplayBasicSentenceQuery>({ tense: 'present', statementOrQuestion: 'statement', subjectId: '', subjectDefiniteness: 'definite', subjectGrammaticalNumber: 'singular', predicateId: '', });
const [displaySentence, setDisplaySentence] = useState<string>(''); const [loading, setLoading] = useState(false);
const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => { setFormData({ ...formData, [e.target.name]: e.target.value, }); };
const handleSubmit = async (e: React.FormEvent) => { e.preventDefault();

if (!formData.subjectId || !formData.predicateId) {
alert('Välj både subjekt och predikat');
return;
}

try {
setLoading(true);
const result = await sentenceService.createSentence(formData);
setDisplaySentence(result.displaySentence || '');
} catch (error) {
console.error('Error creating sentence:', error);
alert('Kunde inte skapa mening');
} finally {
setLoading(false);
}
};
if (nounsLoading || verbsLoading) { return <div>Laddar...</div>; }
return ( <div> <h3>Skapa ett enkelt påstående eller fråga</h3>

  <form onSubmit={handleSubmit}>
    <div className="form-group">
      <label htmlFor="subjectId">Välj ditt subjekt</label>
      <select 
        className="form-control" 
        id="subjectId" 
        name="subjectId"
        value={formData.subjectId}
        onChange={handleChange}
        required
      >
        <option value="">Vem eller vad agerar?</option>
        {nouns.map((noun) => (
          <option key={noun.id} value={noun.id}>
            {noun.singularForm}
          </option>
        ))}
      </select>
    </div>

    <div className="form-group">
      <label htmlFor="subjectDefiniteness">Välj bestämdhet</label>
      <select
        className="form-control"
        id="subjectDefiniteness"
        name="subjectDefiniteness"
        value={formData.subjectDefiniteness}
        onChange={handleChange}
      >
        <option value="definite">bestämd</option>
        <option value="indefinite">obestämd</option>
      </select>
    </div>

    <div className="form-group">
      <label htmlFor="subjectGrammaticalNumber">Välj antal</label>
      <select
        className="form-control"
        id="subjectGrammaticalNumber"
        name="subjectGrammaticalNumber"
        value={formData.subjectGrammaticalNumber}
        onChange={handleChange}
      >
        <option value="singular">singular</option>
        <option value="plural">plural</option>
      </select>
    </div>

    <div className="form-group">
      <label htmlFor="tense">Välj tempus</label>
      <select
        className="form-control"
        id="tense"
        name="tense"
        value={formData.tense}
        onChange={handleChange}
      >
        <option value="present">presens</option>
        <option value="future">futurum</option>
        <option value="perfect">perfekt</option>
        <option value="past">imperfekt</option>
      </select>
    </div>

    <div className="form-group">
      <label htmlFor="statementOrQuestion">Välj struktur: påstående eller fråga</label>
      <select
        className="form-control"
        id="statementOrQuestion"
        name="statementOrQuestion"
        value={formData.statementOrQuestion}
        onChange={handleChange}
      >
        <option value="statement">påstående</option>
        <option value="question">fråga</option>
      </select>
    </div>

    <div className="form-group mb-2">
      <label htmlFor="predicateId">Välj predikat</label>
      <select
        className="form-control"
        id="predicateId"
        name="predicateId"
        value={formData.predicateId}
        onChange={handleChange}
        required
      >
        <option value="">Vad görs eller händer?</option>
        {verbs.map((verb) => (
          <option key={verb.id} value={verb.id}>
            {verb.presentTense}
          </option>
        ))}
      </select>
    </div>

    <button className="btn btn-success" type="submit" disabled={loading}>
      {loading ? 'Skapar...' : 'Visa resultat'}
    </button>

  </form>

{displaySentence && (
<div className="mt-5">
<p>{displaySentence}</p>
</div>
)}

</div>
); };

## 8. Routing Setup

### App.tsx

import React from 'react'; import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'; import { MainLayout } from './components/layout/MainLayout'; import { Home } from './pages/Home'; import { BasicSentence } from './pages/BasicSentence'; import 'bootstrap/dist/css/bootstrap.min.css'; import './App.css';
function App() { return ( <Router> <MainLayout> <Routes> <Route path="/" element={<Home />} /> <Route path="/basic-sentence" element={<BasicSentence />} /> </Routes> </MainLayout> </Router> ); }
export default App;

## 9. Styling

### Kopiera CSS från Blazor (src/App.css)

Kopiera följande filer från Blazor.UI:

- `wwwroot/css/app.css` → `src/App.css`
- `wwwroot/css/bootstrap/bootstrap.min.css` (eller använd npm-versionen)
- `Shared/MainLayout.razor.css` → Integrera i `App.css`
- `Shared/NavMenu.razor.css` → Integrera i `App.css`

**Viktiga CSS-klasser att inkludera:**
.page { display: flex; min-height: 100vh; }
.sidebar { background-image: linear-gradient(180deg, rgb(5, 39, 103) 0%, #3a0647 70%); width: 250px; }
.top-row { background-color: #f7f7f7; border-bottom: 1px solid #d6d5d5; height: 3.5rem; display: flex; align-items: center; }
.navbar-toggler { background-color: rgba(255, 255, 255, 0.1); }
.content { padding-top: 1.1rem; }
.nav-scrollable { display: flex; flex-direction: column; }
.nav-item { font-size: 0.9rem; padding-bottom: 0.5rem; }
.nav-link { color: #d7d7d7; padding: 0.5rem 1rem; text-decoration: none; display: flex; align-items: center; }
.nav-link:hover { background-color: rgba(255, 255, 255, 0.1); color: white; }
.form-group { margin-bottom: 1rem; }
@media (max-width: 768px) { .sidebar { width: 100%; }
.page { flex-direction: column; } }

## 10. Folder Structure

language-skeleton-react/ ├── src/ │ ├── components/ │ │ └── layout/ │ │ ├── MainLayout.tsx │ │ └── NavMenu.tsx │ ├── hooks/ │ │ ├── useNouns.ts │ │ └── useVerbs.ts │ ├── pages/ │ │ ├── Home.tsx │ │ └── BasicSentence.tsx │ ├── services/ │ │ ├── apiClient.ts │ │ ├── nounService.ts │ │ ├── verbService.ts │ │ └── sentenceService.ts │ ├── types/ │ │ └── api.ts │ ├── App.tsx │ ├── App.css │ └── main.tsx ├── public/ ├── package.json └── tsconfig.json

## 11. Implementation Checklist

- [ ] Skapa React-projektet med Vite + TypeScript
- [ ] Installera dependencies (react-router-dom, axios, bootstrap)
- [ ] Skapa folder structure
- [ ] Implementera TypeScript types (api.ts)
- [ ] Skapa API client och services
- [ ] Implementera custom hooks (useNouns, useVerbs)
- [ ] Bygga layout-komponenter (MainLayout, NavMenu)
- [ ] Implementera Home-sidan
- [ ] Implementera BasicSentence-sidan med formulär
- [ ] Kopiera och anpassa CSS från Blazor
- [ ] Testa mot lokalt API (https://localhost:7217)
- [ ] Verifiera alla formulärfält och dropdown-värden
- [ ] Testa mening-generering med olika kombinationer

## 12. Kör React-appen

Appen kommer att köras på `http://localhost:5173`

## 13. Production Build

Detta skapar en production-optimerad build i `dist/`-mappen.

## Viktiga Skillnader: Blazor vs React

| Feature          | Blazor WASM            | React                    |
| ---------------- | ---------------------- | ------------------------ |
| State Management | Component properties   | useState hooks           |
| Lifecycle        | OnInitializedAsync     | useEffect                |
| Forms            | EditForm + InputSelect | Controlled components    |
| DI               | @inject                | Import services directly |
| Routing          | @page directive        | React Router             |
| Styling          | Scoped CSS             | Global CSS / CSS Modules |

## Felsökning

**CORS-problem:**

- Verifiera att API:et kör på `https://localhost:7217`
- Bekräfta att CORS är konfigurerat i API `Program.cs`

**Tom dropdown:**

- Kontrollera browser console för API-fel
- Verifiera att API returnerar data korrekt
- Bekräfta att hooks laddas innan rendering

**Form skickas inte:**

- Kontrollera att både `subjectId` och `predicateId` har värden
- Verifiera request payload i browser DevTools

---

**Författare:** Genererad från Blazor.UI-analys  
**Datum:** 2026-06-11  
**Version:** 1.0
