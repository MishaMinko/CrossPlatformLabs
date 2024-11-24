import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Auth0ProviderWithHistory from './auth/Auth0ProviderWithHistory';
import Home from './pages/Home';
import LabsPage from './pages/LabsPage';
import Profile from './components/Profile';
import Register from './components/Register';
import Login from './components/Login';

const App = () => {
  return (
    <Router>
      <Auth0ProviderWithHistory>
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/labs" component={LabsPage} />
          <Route path="/profile" component={Profile} />
          <Route path="/register" component={Register} />
          <Route path="/login" component={Login} />
        </Switch>
      </Auth0ProviderWithHistory>
    </Router>
  );
};

export default App;
