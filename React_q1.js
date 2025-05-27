function Welcome ({name})
{
    return (
        <h1>
            Hello, {name}! Welcome to React.
        </h1>
    );
}

const root = ReactDOM.createRoot (document.getElementById('root'));
root.render(<Welcome name="User" />);