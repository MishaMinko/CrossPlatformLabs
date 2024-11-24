import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Auth0ProviderWithHistory from './auth/Auth0ProviderWithHistory';
import Layout from './components/Layout';
import Home from './pages/Home';
import LabsPage from './pages/LabsPage';
import Profile from './components/Profile';
import Register from './components/Register';
import Login from './components/Login';
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
  return (
    <Router>
      <Auth0ProviderWithHistory>
        <Layout>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/labs" element={<LabsPage />} />
            <Route path="/profile" element={<Profile />} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login />} />
          </Routes>
        </Layout>
      </Auth0ProviderWithHistory>
    </Router>
  );
};

export default App;
