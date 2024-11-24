import React from 'react';
import { useAuth0 } from '@auth0/auth0-react';

const Profile = () => {
    const { user, isAuthenticated, logout } = useAuth0();

    if (!isAuthenticated) {
        return <div>You need to log in to view this page.</div>;
    }

    return (
        <div>
            <h2>User Profile</h2>
            <p>Username: {user?.name}</p>
            <p>Email: {user?.email}</p>
            <p>Full Name: {user?.given_name} {user?.family_name}</p>
            <button onClick={() => logout({ returnTo: window.location.origin })}>Logout</button>
        </div>
    );
};

export default Profile;
