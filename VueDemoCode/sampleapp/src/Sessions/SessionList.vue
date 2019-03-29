<template>
  <div class="grid-template">
   <table>
    <thead>
      <tr>
        <th v-for="key in columns" :key="key.id"
          @click="sortBy(key)"
          :class="{ active: sortKey == key }">
          {{ key | capitalize }}
          <span class="arrow" :class="sortSessions[key] > 0 ? 'asc' : 'dsc'">
          </span>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="entry in filteredData" :key="entry.id">
        <td v-for="key in columns" :key="key.id">
          {{entry[key]}}
        </td>
      </tr>
    </tbody>
  </table>

    </div>
</template>

<script>

export default {
  name: 'SessionList',
  props: {
    data: Array,
    columns: Array,
    filterKey: String,
  },
  data() {
    const sortSessions = { };
    this.columns.forEach((key) => {
      sortSessions[key] = 1;
    });
    return {
      sortKey: '',
      sortSessions,
    };
  },
  computed: {
    filteredData() {
      // eslint-disable-next-line
      const sortKey = this.sortKey;
      const filterKey = this.filterKey && this.filterKey.toLowerCase();
      const session = this.sortSessions[sortKey] || 1;
      // eslint-disable-next-line
      let data = this.data;
      if (filterKey) {
        data = data.filter(row => Object.keys(row).some(key => String(row[key]).toLowerCase()
          .indexOf(filterKey) > -1));
      }
      if (sortKey) {
        data = data.slice().sort((a, b) => {
          // eslint-disable-next-line
          a = a[sortKey];
          // eslint-disable-next-line
          b = b[sortKey];
          // eslint-disable-next-line
          return (a === b ? 0 : a > b ? 1 : -1) * session;
        });
      }
      return data;
    },
  },
  filters: {
    capitalize(str) {
      return str.charAt(0).toUpperCase() + str.slice(1);
    },
  },
  methods: {
    sortBy(key) {
      this.sortKey = key;
      this.sortSessions[key] = this.sortSessions[key] * -1;
    },
  },

};

</script>
<style>

body {
  font-family: Helvetica Neue, Arial, sans-serif;
  font-size: 14px;
  color: #444;
}

table {
  border: 2px solid #42b983;
  border-radius: 3px;
  background-color: #fff;
}

th {
  background-color: #42b983;
  color: rgba(255,255,255,0.66);
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

td {
  background-color: #f9f9f9;
}

th, td {
  min-width: 120px;
  padding: 10px 20px;
}

th.active {
  color: #fff;
}

th.active .arrow {
  opacity: 1;
}

.arrow {
  display: inline-block;
  vertical-align: middle;
  width: 0;
  height: 0;
  margin-left: 5px;
  opacity: 0.66;
}

.arrow.asc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-bottom: 4px solid #fff;
}

.arrow.dsc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-top: 4px solid #fff;
}
</style>
