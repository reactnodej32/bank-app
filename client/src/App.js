import { useEffect, useState } from "react";
import axios from "axios";
const App = () => {
  const [cat, setMoreCats] = useState({
    catName: "",
  });

  const [allcats, setAllCats] = useState({});

  const { catName } = cat;

  useEffect(() => {
    axios.get("/api/bankaccount").then((res) => {
      setAllCats(res.data);
    });
  }, []);

  const handleSubmit = async (event) => {
    event.preventDefault();
    axios.post("/api/bankaccount", { firstName: catName }).then((res) => {
      setAllCats([...allcats, res.data]);
    });
  };

  const handleChange = (event) => {
    const { value, name } = event.target;

    setMoreCats({ ...cat, [name]: value });
  };

  return (
    <div>
      {allcats.length > 0
        ? allcats.map((cat, i) => <div key={i}>{cat.firstName}</div>)
        : "no cats ):"}
      <br />
      Add more cool cats!
      <form onSubmit={handleSubmit}>
        <input
          name="catName"
          type="text"
          value={catName}
          onChange={handleChange}
          label="cat"
        />

        <button type="submit"> Enter!</button>
      </form>
    </div>
  );
};

export default App;
