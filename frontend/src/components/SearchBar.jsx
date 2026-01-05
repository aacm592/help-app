import Button from "./Button";
import { useEffect, useRef, useState } from "react";

export default function SearchBar({
  onSearch,
  placeholder = "Buscar...",
  items = [],
  onItemClicked,
}) {
  const [text, setText] = useState("");
  const [itemsList, setItemsList] = useState([]);
  const [highlightedIndex, setHighlightedIndex] = useState(-1);
  const [isListVisible, setIsListVisible] = useState(false);
  const searchBarRef = useRef(null);

  useEffect(() => {
    if (text.trim() === "") {
      setItemsList([]);
    } else {
      const filtered = items.filter((item) =>
        item.toLowerCase().includes(text.toLowerCase())
      );
      setItemsList(filtered);
    }
  }, [text, items]);

  useEffect(() => {
    function handleClickOutside(event) {
      if (
        searchBarRef.current &&
        !searchBarRef.current.contains(event.target)
      ) {
        setIsListVisible(false);
      }
    }
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const handleKeyPress = (event) => {
    if (event.key === "Enter") {
      onSearch(text);
      setText("");
      setIsListVisible(false);
    }
  };

  const handleSearchClick = () => {
    onSearch(text);
    setText("");
    setIsListVisible(false);
  };

  const handleItemClick = (item) => {
    onItemClicked(item);
    setText(item);
    setIsListVisible(false);
    setItemsList([]);
  };

  const handleChange = (value) => {
    setText(value);
    setIsListVisible(true);
    setHighlightedIndex(-1);
  };

  return (
    <div ref={searchBarRef} className="relative w-full">
      <div className="flex items-center w-full bg-white border border-gray-500 p-1.5 pl-5 rounded-xl shadow-sm focus-within:ring-2 focus-within:ring-indigo-500 transition-all">
        <input
          type="text"
          placeholder={placeholder}
          value={text}
          onChange={(e) => handleChange(e.target.value)}
          onKeyUp={handleKeyPress}
          onFocus={() => setIsListVisible(true)}
          className="w-full text-lg border-none outline-none bg-transparent placeholder-gray-400"
        />
        <Button
          onClick={handleSearchClick}
          className="flex items-center justify-center p-2"
          outline={false}
        >
          <span className="material-symbols-outlined text-2xl">search</span>
        </Button>
      </div>

      {isListVisible && text.trim() && itemsList.length > 0 && (
        <ul
          className="absolute left-0 right-0 z-50 mt-1 max-h-60 overflow-y-auto bg-gray-50 flex flex-col py-2 shadow-xl rounded-b-2xl border-t border-gray-100"
          onMouseLeave={() => setHighlightedIndex(-1)}
        >
          {itemsList.map((item, index) => (
            <li
              key={item}
              className={`cursor-pointer text-left py-3 px-5 mx-2 rounded-lg transition-colors ${
                index === highlightedIndex
                  ? "bg-indigo-50 text-indigo-600 font-medium"
                  : "text-gray-700 hover:bg-gray-100"
              }`}
              onClick={() => handleItemClick(item)}
              onMouseEnter={() => setHighlightedIndex(index)}
            >
              {item}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
